using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace demo_csdlnc.Models
{
    public class TieuChiSinhVien
    {
        [Key]
        public int MaDanhGia { get; set; }
        public int MaSV { get; set; }
        public int MaTieuChi { get; set; }
        public int Diem { get; set; }
        public string NhanXet { get; set; }
        [ForeignKey("MaSV")]
        public SinhVien SinhVien { get; set; }
        [ForeignKey("MaTieuChi")]
        public TieuChi TieuChi { get; set; }
    }
}
