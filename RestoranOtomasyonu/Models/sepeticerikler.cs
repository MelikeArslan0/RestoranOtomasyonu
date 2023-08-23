using System.ComponentModel.DataAnnotations;

namespace RestoranOtomasyonu.Models
{
    public class sepeticerikler
    {
        [Key]
        public int Id { get; set; }
        public sepet sepet { get; set; }
        public int SepetID { get; set; }    
        public icerik icerik { get; set; }  
        public int IcerikID { get; set; }   
    }
}
