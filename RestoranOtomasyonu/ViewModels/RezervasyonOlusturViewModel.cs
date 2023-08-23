using System.ComponentModel.DataAnnotations;

namespace RestoranOtomasyonu.ViewModels
{
    public class RezervasyonOlusturViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string Telefon { get; set; }
        public int Kisi { get; set; }
        public DateTime Tarih { get; set; }
    }
}
