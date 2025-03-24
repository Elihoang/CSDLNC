using demo_csdlnc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace demo_csdlnc.Controllers
{
    public class KetQuaController : Controller
    {
        private readonly AppDbContext _context;

        public KetQuaController(AppDbContext context)
        {
            _context = context;
        }
         
        // GET: KetQua
        public IActionResult Index()
        {
            var username = HttpContext.Session.GetString("Username");
            var role = HttpContext.Session.GetString("Role");
            var maAccount = HttpContext.Session.GetInt32("MaAccount");

            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Account"); 
            }

            IQueryable<KetQua> ketQuas = _context.KetQuas.Include(k => k.SinhVien).Include(k => k.NguoiXetDuyet);

            if (role == "SinhVien")
            {
                var sinhVien = _context.SinhViens.FirstOrDefault(s => s.MaSV == maAccount);
                if (sinhVien != null)
                {
                    ketQuas = ketQuas.Where(k => k.MaSV == sinhVien.MaSV);
                }
                else
                {
                    return Forbid(); 
                }
            }

            return View(ketQuas.ToList());
        }
        

        // GET: KetQua/Details/5
        public IActionResult Details(int id)
        {
            var ketQua = _context.KetQuas.Include(k => k.SinhVien).Include(k => k.NguoiXetDuyet)
                .FirstOrDefault(k => k.MaKetQua == id);
            if (ketQua == null)
                return NotFound();
            return View(ketQua);
        }

        // GET: KetQua/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return Unauthorized();
            }
            var sinhViens = _context.SinhViens.ToList();
            var nguoiXetDuyets = _context.NguoiXetDuyets.Include(n => n.Account).ToList();

            ViewBag.MaSV = sinhViens.Any() ? new SelectList(sinhViens, "MaSV", "HoTen") : null;
            ViewBag.MaNguoiXetDuyet = nguoiXetDuyets.Any() ? new SelectList(nguoiXetDuyets, "MaNguoiXetDuyet", "Account.Username") : null;

            return View();
        }

        // POST: KetQua/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(KetQua ketQua)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return Unauthorized();
            }
            if (ModelState.IsValid)
            {
                _context.KetQuas.Add(ketQua);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(ketQua);
        }

        // GET: KetQua/Edit/5
        public IActionResult Edit(int id)
        {
            var role = HttpContext.Session.GetString("Role");
            var maAccount = HttpContext.Session.GetInt32("MaAccount");

            if (string.IsNullOrEmpty(role))
            {
                return RedirectToAction("Login", "Account");
            }
            if (role != "Admin" && role != "NguoiXetDuyet")
            {
                return Unauthorized();
            }
            var ketQua = _context.KetQuas.Include(kq => kq.SinhVien).FirstOrDefault(s => s.MaKetQua == id);

            if (ketQua == null)
            {
                return NotFound();
            }
            var sinhViens = _context.SinhViens.ToList();
            var nguoiXetDuyets = _context.NguoiXetDuyets.Include(n => n.Account).ToList();
            ViewBag.TenSinhVien = ketQua.SinhVien?.HoTen ?? "Không tìm thấy";

            ViewBag.MaSV = sinhViens.Any() ? new SelectList(sinhViens, "MaSV", "HoTen") : new SelectList(new List<SinhVien>());
            ViewBag.MaNguoiXetDuyet = nguoiXetDuyets.Any() ? new SelectList(nguoiXetDuyets, "MaNguoiXetDuyet", "Account.Username") : new SelectList(new List<NguoiXetDuyet>());

            // Danh sách xếp loại
            ViewBag.XepLoaiList = new List<SelectListItem>
            {
                new SelectListItem { Value = "Đạt", Text = "Đạt" },
                new SelectListItem { Value = "Không đạt", Text = "Không đạt" }
            };

            ViewBag.Role = role;

            return View(ketQua);
        }


        // POST: KetQua/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, KetQua ketQua)
        {

            if (HttpContext.Session == null)
            {         
                return RedirectToAction("Login", "Account");
            }

            var role = HttpContext.Session.GetString("Role");
            var maAccount = HttpContext.Session.GetInt32("MaAccount");

            if (string.IsNullOrEmpty(role))
            {
                return RedirectToAction("Login", "Account");
            }


            if (id != ketQua.MaKetQua)
                return NotFound();

            if (!ModelState.IsValid)
            {
                _context.Update(ketQua);
                _context.SaveChanges();
            }
           

            return RedirectToAction(nameof(Index));
        }

        // GET: KetQua/Delete/5
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return Unauthorized();
            }
            var ketQua = _context.KetQuas.Include(k => k.SinhVien).Include(k => k.NguoiXetDuyet)
                .FirstOrDefault(k => k.MaKetQua == id);
            if (ketQua == null)
                return NotFound();
            return View(ketQua);
        }

        // POST: KetQua/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return Unauthorized();
            }
            var ketQua = _context.KetQuas.Find(id);
            if (ketQua != null)
            {
                _context.KetQuas.Remove(ketQua);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
