using System.ComponentModel.DataAnnotations;

namespace RestoranOtomasyonu.Models
{
    public class geribildirim
    {
        [Key]
        public int GID { get; set; }
        public int MusteriID { get; set; }
        public musteri musteri { get; set; }
        public string Aciklama { get; set; }
        public int YildizPuan { get; set; }


    }
}
