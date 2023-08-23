using Microsoft.EntityFrameworkCore;
using RestoranOtomasyonu.Models;
using RestoranOtomasyonu.ViewModels;

namespace RestoranOtomasyonu.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public virtual DbSet<kategori> kategori { get; set; }
        public virtual DbSet<urunler> urunler { get; set; }

        public virtual DbSet<icerik> icerik { get; set; }
        public virtual DbSet<terminal> terminal { get; set; }
        public virtual DbSet<geribildirim> geribildirim { get; set; }
      //  public virtual DbSet<siparisler> siparisler { get; set; }
        public virtual DbSet<musteri> musteri { get; set; }
        public virtual DbSet<masa> masa { get; set; }
        public virtual DbSet<yetkilitablo> yetkilitablo { get; set; }
        public virtual DbSet<sepet> sepet { get; set; }
        public DbSet<RezervasyonOlusturViewModel>? RezervasyonOlusturViewModel { get; set; }
        public DbSet<footer> footer { get; set; }
        public DbSet<hakkinda> hakkinda { get; set; }
        public DbSet<masasayisi> masasayisi { get; set; }
        public DbSet<GeriBildirimview> GeriBildirimview { get; set; }
     
        public DbSet<puankayit> puankayit { get; set; }

        public DbSet<kayitolviewmodel> kayitolviewmodel { get; set; }
        public musteri GetMusteriByTelefon(string telefon)
        {
            return musteri.FirstOrDefault(m => m.Telefon == telefon);
        }

        public DbSet<PuanSorgulaViewModel> PuanSorgulaViewModel { get; set; }

        public DbSet<DaimiKayitModelview> DaimiKayitModelview { get; set; }

        public DbSet<UrunDegerlendirViewModel> UrunDegerlendirViewModel { get; set; }
    }
}
