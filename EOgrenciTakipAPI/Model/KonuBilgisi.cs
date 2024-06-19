using System.ComponentModel.DataAnnotations;

namespace EOgrenciTakipAPI.Model
{
    public class KonuBilgisi
    {
        [Key]
        public string KonuBilgisiID { get; set; }
        public string KonuIsmi { get; set; }
        public ICollection<DersBilgisi> DersBilgileri { get; set; }
    }
}
