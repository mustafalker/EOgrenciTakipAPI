namespace EOgrenciTakipAPI.Model
{
    public class DersBilgisi
    {
        public string DersProgramiID { get; set; }
        public int HaftadaDerseAyrilanSure { get; set; }
        public int Ay { get; set; }
        public string Hafta { get; set; }
        public string KonuBilgisiID { get; set; }

        public DersProgrami DersProgrami { get; set; }
        public KonuBilgisi KonuBilgisi { get; set; }
    }
}
