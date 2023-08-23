using System.ComponentModel.DataAnnotations;

namespace RestoranOtomasyonu.Models
{
    public class terminal
    {
        [Key]
        public int TerminalID { get; set; }
        public string TAd { get; set; }
        public ICollection<sepet>? sepet { get; set; }
    }
}
