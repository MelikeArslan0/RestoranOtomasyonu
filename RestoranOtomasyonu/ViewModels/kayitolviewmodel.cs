using System.ComponentModel.DataAnnotations;

namespace RestoranOtomasyonu.ViewModels
{
    public class kayitolviewmodel
    {
        [Key]
        public int DaimiId { get; set; }
        public string Ad { get; set; }
        public string SoyAd { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }

        public string KullanciAdi { get; set; }

        public string Sifre { get; set; }
        public string Puan { get; set; }
    }
}
