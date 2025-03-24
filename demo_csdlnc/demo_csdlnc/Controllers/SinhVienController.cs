using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using demo_csdlnc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace demo_csdlnc.Controllers
{
    
    public class SinhVienController : Controller
    {
        private readonly AppDbContext _context;

        public SinhVienController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var role = HttpContext.Session.GetString("Role"); 

            if (role == "Admin" || role == "NguoiXetDuyet")
            {
                var allSinhVien = _context.SinhViens.Include(sv => sv.Lop).ToList();

                return View(allSinhVien);
            }
            else if (role == "SinhVien")
            {
                var userId = HttpContext.Session.GetInt32("MaAccount");
                var roles = HttpContext.Session.GetString("Role");

                Console.WriteLine($"Role: {roles}, UserId: {userId}");
                var sinhVien = _context.SinhViens.Include(sv => sv.Lop).FirstOrDefault(s => s.MaAccount == userId); // Include Lop here!
                ViewBag.MaLop = new SelectList(_context.Lops, "MaLop", "TenLop", sinhVien?.MaLop);

                if (sinhVien == null)
                {
                    return NotFound(); 
                }

                var sinhViens = new List<SinhVien> { sinhVien };
                return View(sinhViens);
            }
            return Unauthorized();
        }

        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return Unauthorized();
            }

            ViewBag.MaLop = new SelectList(_context.Lops, "MaLop", "TenLop");
            return View();
        }


        [HttpPost]
        public IActionResult Create(SinhVien sinhVien)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return Unauthorized();
            }

            // Kiểm tra xem MaLop có tồn tại trong database không
            var lop = _context.Lops.Find(sinhVien.MaLop);
            if (lop == null)
            {
                ViewBag.MaLop = new SelectList(_context.Lops, "MaLop", "TenLop");
                return View(sinhVien); 
            }

            _context.SinhViens.Add(sinhVien);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            var role = HttpContext.Session.GetString("Role");
            var userId = HttpContext.Session.GetInt32("MaAccount");

            if (role == "Admin" || role == "NguoiXetDuyet")
            {
                var sinhVien = _context.SinhViens.Include(sv => sv.Lop).FirstOrDefault(s => s.MaSV == id);
                if (sinhVien == null)
                {
                    return NotFound();
                }

                ViewBag.MaLop = new SelectList(_context.Lops, "MaLop", "TenLop", sinhVien.MaLop);
                ViewBag.MaAccount = new SelectList(_context.Accounts, "MaAccount", "Username", sinhVien.MaAccount);
                return View(sinhVien);
            }
            else if (role == "SinhVien")
            {
                var sinhVien = _context.SinhViens.Include(sv => sv.Lop).FirstOrDefault(s => s.MaAccount == userId);
                if (sinhVien == null)
                {
                    return NotFound();
                }

                ViewBag.MaLop = new SelectList(_context.Lops, "MaLop", "TenLop", sinhVien.MaLop);
                ViewBag.MaAccount = new SelectList(_context.Accounts, "MaAccount", "Username", sinhVien.MaAccount);
                return View(sinhVien);
            }

            return Unauthorized();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SinhVien sinhVien)
        {
            try
            {
                var role = HttpContext.Session.GetString("Role");
                var userId = HttpContext.Session.GetInt32("MaAccount");
                Console.WriteLine($"SinhVien MaSV: {sinhVien.MaSV}, HoTen: {sinhVien.HoTen}");
                if (role == "Admin" || role == "NguoiXetDuyet")
                {
                    if (ModelState.IsValid)
                    {
                        var sinhVienToUpdate = _context.SinhViens
                                                       .Include(sv => sv.Account) 
                                                       .Include(sv => sv.Lop)      
                                                       .FirstOrDefault(s => s.MaSV == sinhVien.MaSV); 

                        if (sinhVienToUpdate == null)
                        {
                            return NotFound(); 
                        }
                        sinhVienToUpdate.HoTen = sinhVien.HoTen;  
                        sinhVienToUpdate.NgaySinh = sinhVien.NgaySinh;
                        sinhVienToUpdate.GioiTinh = sinhVien.GioiTinh;
                        sinhVienToUpdate.MaLop = sinhVien.MaLop; 
                        sinhVienToUpdate.Email=sinhVien.Email;
                        sinhVienToUpdate.SoDienThoai = sinhVien.SoDienThoai;    

                        if (sinhVien.Account != null)
                        {
                            sinhVienToUpdate.Account = sinhVien.Account;  
                        }
                        _context.SaveChanges();
                        return RedirectToAction("Index");
                    }

                }

                if (role == "SinhVien")
                {
                    if (userId == sinhVien.MaAccount)
                    {
                        if (ModelState.IsValid)
                        {
                            _context.SinhViens.Update(sinhVien);
                            _context.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ViewBag.MaLop = new SelectList(_context.Lops, "MaLop", "TenLop", sinhVien.MaLop);
                            ViewBag.MaAccount = new SelectList(_context.Accounts, "MaAccount", "Username", sinhVien.MaAccount);
                            return View(sinhVien);
                        }
                    }
                    else
                    {
                        return Forbid();
                    }
                }

                return Unauthorized();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
                ModelState.AddModelError("", "Đã xảy ra lỗi khi cập nhật thông tin sinh viên.");
                return View(sinhVien);
            }
        }



        public IActionResult Details(int id)
        {
            var role = HttpContext.Session.GetString("Role");
            var userId = HttpContext.Session.GetInt32("MaAccount");

            if (string.IsNullOrEmpty(role))
            {
                return Unauthorized(); // Nếu role không có giá trị, trả về Unauthorized
            }

            // Nếu là Admin, có thể xem thông tin chi tiết của tất cả sinh viên
            if (role == "Admin")
            {
                var sinhVien = _context.SinhViens.Include(sv => sv.Lop).FirstOrDefault(s => s.MaSV == id);

                if (sinhVien == null)
                {
                    return NotFound();
                }

                return View(sinhVien);
            }

            if (role == "SinhVien")
            {
                if (userId == id)
                {
                    var sinhVien = _context.SinhViens.Include(sv => sv.Lop).FirstOrDefault(s => s.MaAccount == id);

                    return View(sinhVien);
                }

            }

            return Unauthorized();
        }
        // 🔹 Chỉ Admin có thể xóa sinh viên
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return Unauthorized();
            }

            var sinhVien = _context.SinhViens.Find(id);
            if (sinhVien == null) return NotFound();

            return View(sinhVien);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return Unauthorized();
            }

            var sinhVien = _context.SinhViens.Find(id);
            if (sinhVien != null)
            {
                _context.SinhViens.Remove(sinhVien);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
