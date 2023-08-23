using System.ComponentModel.DataAnnotations;

namespace RestoranOtomasyonu.Models
{
    public class footer
    {
        [Key] 
        public int Id { get; set; }
        public string Ara { get; set; }   
        public string mail { get; set; }
        public string Konum { get; set; }
        public string instagram { get; set; }
        public string twitter { get; set; }
        public string facebook { get; set; }
    }
}
