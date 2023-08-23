using System.ComponentModel.DataAnnotations;

namespace RestoranOtomasyonu.ViewModels
{
    public class DaimiKayitModelview
    {
        [Key]
        public int MusteriID { get; set; }
        public String Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public bool Daimi { get; set; }
        public int? Puan { get; set; }
        public string? Mail { get; set; }

    }
}
