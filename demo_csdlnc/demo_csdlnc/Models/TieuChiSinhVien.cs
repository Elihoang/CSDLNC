using demo_csdlnc.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class TieuChiSinhVien
{
    [Key]
    public int MaDanhGia { get; set; }

    [Required(ErrorMessage = "Mã sinh viên không được để trống")]
    public int MaSV { get; set; }

    [Required(ErrorMessage = "Mã tiêu chí không được để trống")]
    public int MaTieuChi { get; set; }

    [Range(0, 100, ErrorMessage = "Điểm phải nằm trong khoảng 0 - 100")]
    public int Diem { get; set; } 

    [StringLength(500, ErrorMessage = "Nhận xét không được vượt quá 500 ký tự")]
    public string NhanXet { get; set; }

    [StringLength(500, ErrorMessage = "Minh chứng không được vượt quá 500 ký tự")]
    public string MinhChung { get; set; } 

    // 🔹 Khóa ngoại
    [ForeignKey("MaSV")]
    public SinhVien? SinhVien { get; set; }

    [ForeignKey("MaTieuChi")]
    public TieuChi? TieuChi { get; set; }
}
