using System.ComponentModel.DataAnnotations;

namespace RestoranOtomasyonu.Models
{
    public class icerik
    {
        [Key]
        public int IcerikID { get; set; }    
        public int urunlerID { get; set; }     
        public string? IcerikAD { get; set; }      
        public urunler urunler { get; set; }
      
        public virtual ICollection<sepeticerikler>? sepeticerikler { get; set; }
    }
}
