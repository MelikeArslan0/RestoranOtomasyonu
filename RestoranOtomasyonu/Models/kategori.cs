using System.ComponentModel.DataAnnotations;

namespace RestoranOtomasyonu.Models
{
      public class kategori
        {
            [Key]
            public int KategoriID { get; set; }
            public string KategoriAd { get; set; }
            public ICollection<urunler> urunler { get; set; }
        }
    
}
