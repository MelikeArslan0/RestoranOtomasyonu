using System.ComponentModel.DataAnnotations;

namespace RestoranOtomasyonu.ViewModels
{
    public class PuanSorgulaViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Ad { get; set; }
        public string SoyAd { get; set; }
        public int? Puan { get; set; }
    }
}
