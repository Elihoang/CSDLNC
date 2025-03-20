using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace demo_csdlnc.Models
{
    public class SinhVien
    {
        [Key]
        public int MaSV { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public int MaLop { get; set; }
        [ForeignKey("MaLop")]
        public Lop Lop { get; set; }
    }

}
