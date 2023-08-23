using System.ComponentModel.DataAnnotations;

namespace RestoranOtomasyonu.Models
{
    public class yetkilitablo
    {
        [Key]
        public int ID { get; set; }
        public int KTC { get; set; }
        public string KUnvan { get; set; }
        public string KAdSoyad { get; set; }
        public int KTel { get; set; }
    }
}
