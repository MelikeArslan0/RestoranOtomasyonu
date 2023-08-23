using System.ComponentModel.DataAnnotations;

namespace RestoranOtomasyonu.Models
{
    public class hakkinda
    {
        [Key]
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
    }
}
