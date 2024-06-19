using System.ComponentModel.DataAnnotations;

namespace EOgrenciTakipAPI.Model
{
    public class MufredatDersler
    {
        [Key]
        public string MufredatDersId { get; set; }
        public string DersSinavTuru { get; set; }
        public string DersIsmi { get; set; }
    }
}
