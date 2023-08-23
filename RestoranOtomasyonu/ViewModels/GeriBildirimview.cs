using Microsoft.CodeAnalysis.Operations;
using System.ComponentModel.DataAnnotations;

namespace RestoranOtomasyonu.ViewModels
{
    public class GeriBildirimview
    {
        [Key]
        public string Id { get; set; }
        public string Ad { get; set; }
        public string SoyAD { get; set; }
        public string Telefon { get; set; }
        public string Acıklama { get; set;}
        public int puan { get; set; }



    }
}
