using demo_csdlnc.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class ThamGiaHoatDong
{
    [Key]
    public int MaThamGia { get; set; }

    [Required(ErrorMessage = "Mã sinh viên không được để trống")]
    public int MaSV { get; set; }

    [Required(ErrorMessage = "Tên hoạt động không được để trống")]
    [StringLength(100, ErrorMessage = "Tên hoạt động không được vượt quá 100 ký tự")]
    public string TenHoatDong { get; set; }

    [Required(ErrorMessage = "Ngày tham gia không được để trống")]
    [DataType(DataType.Date)]
    public DateTime NgayThamGia { get; set; }

    [Required(ErrorMessage = "Mã tiêu chí không được để trống")]
    public int MaTieuChi { get; set; }  // Liên kết với tiêu chí

    [Range(0, 100, ErrorMessage = "Điểm số phải từ 0 đến 100")]
    public int DiemSo { get; set; }

    [StringLength(500, ErrorMessage = "Minh chứng không được vượt quá 500 ký tự")]
    public string MinhChung { get; set; } // Link hoặc file đính kèm

    // 🔹 Khóa ngoại
    [ForeignKey("MaSV")]
    public SinhVien SinhVien { get; set; }

    [ForeignKey("MaTieuChi")]
    public TieuChi TieuChi { get; set; }
}
