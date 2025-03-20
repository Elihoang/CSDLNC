using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace demo_csdlnc.Models
{
    public class KetQua
    {
        [Key]
        public int MaKetQua { get; set; }
        public int MaSV { get; set; }
        public string NamHoc { get; set; }
        public string XepLoai { get; set; }
        public string GhiChu { get; set; }
        public int MaNguoiXetDuyet { get; set; }
        [ForeignKey("MaSV")]
        public SinhVien SinhVien { get; set; }
        [ForeignKey("MaNguoiXetDuyet")]
        public NguoiXetDuyet NguoiXetDuyet { get; set; }
    }
}
