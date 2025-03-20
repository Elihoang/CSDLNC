using System.ComponentModel.DataAnnotations;

namespace demo_csdlnc.Models
{
    public class TieuChi
    {
        [Key]
        public int MaTieuChi { get; set; }
        public string TenTieuChi { get; set; }
        public string MoTa { get; set; }
    }
}
