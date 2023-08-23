using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.Versioning;
using RestoranOtomasyonu.DAL;
using RestoranOtomasyonu.Models;
using RestoranOtomasyonu.ViewModels;
using System.Diagnostics;
using RestoranOtomasyonu.Extensions;
namespace RestoranOtomasyonu.Controllers
{ 
    public class HomeController : Controller
    {
        private readonly DataContext _context;
        public HomeController(DataContext context)
        {
            _context = context;
        }      
        public IActionResult Index()
        {
            int MasaID = 2;
            HttpContext.Session.SetInt32("MasaID", MasaID);
            TempData["MasaID"] = MasaID;          
            var urunler = _context.urunler.ToList();
            var icerikler = _context.icerik.ToList();
            var kategoriler = _context.kategori.ToList();
            var musteri=_context.musteri.ToList();
            ViewBag.musteri = musteri;
            var hakkinda = _context.hakkinda.ToList();
            ViewBag.hakkinda = hakkinda;
            var geribildirim=_context.geribildirim.ToList();
            ViewBag.geribildirim = geribildirim;
            var model = new MenuViewModel
            {
                Urunler = urunler,
                Icerikler = icerikler,
                kategoris = kategoriler,             
            };
            return View(model);
        } 
        public IActionResult GeriiBildirim(GeriBildirimview request)
        {
            if (ModelState.IsValid)
            {
                musteri musteri = new musteri
                {
                    Ad = request.Ad,
                    Soyad = request.SoyAD,
                    Telefon= request.Telefon
                };
                _context.musteri.Add(musteri);
                _context.SaveChanges();
                geribildirim geribildirim = new geribildirim
                {
                    MusteriID = musteri.MusteriID,
                    Aciklama = request.Acıklama,
                    YildizPuan = request.puan
                };
                _context.geribildirim.Add(geribildirim);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            foreach (var modelStateEntry in ModelState.Values)
            {
                foreach (var error in modelStateEntry.Errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            // Hata mesajları ile birlikte tekrar view'a dönün
            return View(request);
        }
        public IActionResult Menu(int MasaID,int UrunID)
        {
            HttpContext.Session.SetInt32("MasaID", MasaID);
            HttpContext.Session.SetInt32("UrunID",UrunID);

            //int masaID = Convert.ToInt32(TempData["MasaID"]);
            var urunler = _context.urunler.ToList();
            var icerikler = _context.icerik.ToList();
            var kategoriler = _context.kategori.ToList();
            var model = new MenuViewModel
            {
                Urunler = urunler,
                Icerikler = icerikler,
                kategoris = kategoriler
            };
            TempData["MasaID"] = MasaID;
            TempData["UrunID"] = UrunID;
            return View(model);
        }
        public IActionResult urundegerlendir()
        {
            int? UrunID = HttpContext.Session.GetInt32("UrunID");
            if (UrunID.HasValue)
            {
               
                  return RedirectToAction("Menu");
            }
            return View();
        }
        public IActionResult Sepet(int id)
        {
             var masasayisi = _context.masasayisi.ToList();
            ViewBag.masasayisi = masasayisi;

            var sepetUrunler = _context.sepet.Where(x => x.SepetID == id)
                            .Include(s => s.urunler)
                            .Include(s => s.icerik)
                            .ToList();

            return View(sepetUrunler);
        }
        public IActionResult Sepetim(int UrunId, int MasaID)
        {
            HttpContext.Session.SetInt32("MasaID", MasaID);
            var urun = _context.urunler
                               .Include(x => x.icerik)
                               .FirstOrDefault(u => u.UrunID == UrunId);
            if (urun == null)
            {
                 return View("Error");
            }
            TempData["MasaID"] = MasaID;
            ViewBag.Masa = _context.masasayisi.FirstOrDefault(x => x.ID == MasaID)?.AD;
            return View(urun);
        }
        [HttpPost]
        public IActionResult Sepetim(int[] Icerikler, int UrunId, int MasaID, int Adet, double Tutar)
        {
            MasaID = HttpContext.Session.GetInt32("MasaID") ?? 0;
          
            sepet sepetim = new sepet();
            sepetim.urunlerID = UrunId;
            sepetim.IcerikID = 1;
            sepetim.Adet = Adet;
            sepetim.Tutar = Tutar;
            sepetim.MasaID = MasaID;
            sepetim.TerminalID = 4;
            _context.Set<sepet>().Add(sepetim);
            _context.SaveChanges();
            for (int i = 0; i < Icerikler.Length; i++)
            {
                sepeticerikler icerik = new sepeticerikler();
                icerik.IcerikID = Icerikler[i];
                icerik.SepetID = sepetim.SepetID;
                _context.Set<sepeticerikler>().Add(icerik);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", new { urunId = UrunId, masaID = MasaID });     
        }
        public IActionResult SepeteEkle(int urunID, List<int> icerikler)
        {
            var urun = _context.urunler.FirstOrDefault(u => u.UrunID == urunID);
            Models.sepet sepet = new sepet();
            if (urun != null)
            {              
                var seciliIcerikler = _context.icerik.ToList();
                sepet = new sepet
                {
                    urunlerID = urun.UrunID,
                    IcerikID = seciliIcerikler.FirstOrDefault().IcerikID,
                    Adet = sepet.Adet,
                    Tutar = sepet.Tutar,
                };
                _context.sepet.Add(sepet);
                _context.SaveChanges();          
            }    
            return RedirectToAction("Sepetim", new { UrunID = urunID});
        }
        public IActionResult Hakkinda()
        {
            var hakkinda = _context.hakkinda.ToList();
            var footer = _context.footer.ToList();
            ViewBag.footer = footer;
            return View(hakkinda);
        }      
        public IActionResult MasaAyir(RezervasyonOlusturViewModel request)
        {
            if (ModelState.IsValid)
            {
                musteri musteri = new musteri();
                musteri.Ad = request.Isim;
                musteri.Soyad = request.Soyisim;
                musteri.Telefon = request.Telefon;
                _context.musteri.Add(musteri);
                _context.SaveChanges();

                masa masa=new masa();
                masa.MusteriID = musteri.MusteriID;
                masa.RezervasyonTarihi = request.Tarih;
                _context.masa.Add(masa);
                _context.SaveChanges();
               return RedirectToAction("Index");
            }
            return View();
        }     
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}