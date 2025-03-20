using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace demo_csdlnc.Models
{
    public class DangKy
    {
        [Key]
        public int MaDangKy { get; set; }
        public int MaSV { get; set; }
        public DateTime NgayDangKy { get; set; }
        public string TrangThai { get; set; }
        public int? MaNguoiXetDuyet { get; set; }
        [ForeignKey("MaSV")]
        public SinhVien SinhVien { get; set; }
        [ForeignKey("MaNguoiXetDuyet")]
        public NguoiXetDuyet NguoiXetDuyet { get; set; }
    }
}
