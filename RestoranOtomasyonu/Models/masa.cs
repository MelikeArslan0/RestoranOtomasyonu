using System.ComponentModel.DataAnnotations;

namespace RestoranOtomasyonu.Models
{
    public class masa
    {
        [Key]
        public int MasaID { get; set; }
        public int MasaNumarası { get; set; }
         public masasayisi  masasayisi{get;set;}
        public musteri musteri { get; set; }
        public int MusteriID { get; set; }
        public DateTime RezervasyonTarihi { get; set; }
        public int KisiSayisi { get; set; }

        public ICollection<sepet>? sepet { get; set; }
    }
}
