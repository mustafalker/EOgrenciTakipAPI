using System.ComponentModel.DataAnnotations;

namespace EOgrenciTakipAPI.Model
{
    public class MufredatKonular
    {
        [Key]
        public string MufredatKonuId { get; set; }
        public string DersSinavTuru { get; set; }
        public string DersIsmi { get; set; }
        public string KonuIsmi { get; set; }
    }
}
