using System.ComponentModel.DataAnnotations;

namespace RestoranOtomasyonu.Models
{
    public class sepet
    {
        [Key]
        public int SepetID { get; set; }
        public urunler urunler { get; set; }
        public int urunlerID { get; set; }     
        public int IcerikID { get; set; }
        public icerik icerik { get; set; }
        public int Adet { get; set; }
        public double Tutar { get; set;}
        public int MasaID { get; set; }
        public masa masa { get; set; }
        public int TerminalID { get; set; }
        public terminal terminal { get; set; }

    }
}
