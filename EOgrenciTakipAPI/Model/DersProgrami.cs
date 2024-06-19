namespace EOgrenciTakipAPI.Model
{
    public class DersProgrami
    {
        public string DersProgramiID { get; set; }
        public int GunlukCalismaSaati { get; set; }
        public int HaftadaCalisilacakGunSayisi { get; set; }
        public ICollection<DersBilgisi> DersBilgileri { get; set; }
    }
}
