using RestoranOtomasyonu.Models;

namespace RestoranOtomasyonu.ViewModels
{
    public class MenuViewModel
    {
            public List<urunler> Urunler { get; set; }
            public List<icerik> Icerikler { get; set; }
        public List<kategori> kategoris { get; set; }

    }
}
