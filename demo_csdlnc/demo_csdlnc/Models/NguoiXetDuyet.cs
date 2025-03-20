using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demo_csdlnc.Models
{
    public class NguoiXetDuyet
    {
        [Key]
        public int MaNguoiXetDuyet { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public int MaAccount { get; set; }
        [ForeignKey("MaAccount")]
        public Account Account { get; set; }
    }
}
