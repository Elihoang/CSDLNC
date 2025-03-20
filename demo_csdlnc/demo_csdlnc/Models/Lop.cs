using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace demo_csdlnc.Models
{
    public class Lop
    {
        [Key]
        public int MaLop { get; set; }
        public string TenLop { get; set; }
        public int MaKhoa { get; set; }
        [ForeignKey("MaKhoa")]
        public Khoa Khoa { get; set; }
        public ICollection<SinhVien> SinhViens { get; set; }
    }
}
