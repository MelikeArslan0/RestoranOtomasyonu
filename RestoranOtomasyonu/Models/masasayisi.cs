using System.ComponentModel.DataAnnotations;

namespace RestoranOtomasyonu.Models
{
    public class masasayisi
    {
        [Key]
        public int ID { get; set; }
        public string AD { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int AlanID { get; set; }
        public int AlanNo { get; set; }
        public ICollection<masa>? masa { get; set; }
    }
}
