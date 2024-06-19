using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EOgrenciTakipAPI.Model
{
    public class Ogrenci
    {
        public int OgrenciID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Alan { get; set; }
        public int MinHedef { get; set; }
        public int MaxHedef { get; set; }
    }
}
