using System.ComponentModel.DataAnnotations;

namespace RestoranOtomasyonu.Models
{
    public class urunler
    {
        [Key]
        public int UrunID { get; set; }
        public int? KategoriID { get; set; }
        public kategori? kategori { get; set; }
        public string? UrunAD { get; set; }
        public int? UrunFiyat { get; set; }
        public string? ResimYap { get; set; }
        public bool puandurum{ get; set; }
        public int? Puan { get; set; }
        public virtual ICollection<icerik>? icerik { get; set; }
        //public virtual ICollection<siparisler>? siparisler { get; set; }
        public virtual ICollection<sepet>?sepet { get; set; }
    }
}
