using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace demo_csdlnc.Models
{
    public class ThamGiaHoatDong
    {
        [Key]
        public int MaThamGia { get; set; }
        public int MaSV { get; set; }
        public string TenHoatDong { get; set; }
        public DateTime NgayThamGia { get; set; }
        public int DiemSo { get; set; }
        [ForeignKey("MaSV")]
        public SinhVien SinhVien { get; set; }
    }

}