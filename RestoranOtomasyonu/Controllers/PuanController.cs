using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestoranOtomasyonu.DAL;
using RestoranOtomasyonu.Models;
using RestoranOtomasyonu.ViewModels;
using System.Security.Claims;

namespace RestoranOtomasyonu.Controllers
{
    public class PuanController : Controller
    {
        private readonly DataContext _context;
        public PuanController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            int MasaID = 2;
            HttpContext.Session.SetInt32("MasaID", MasaID);
            TempData["MasaID"] = MasaID;

            return View();
        }    
        public IActionResult DaimiKayit(DaimiKayitModelview request)
        {
            if (ModelState.IsValid)
            {
                request.Daimi = true;
                request.Puan = 0;
                musteri musteri = new musteri
                {                 
                    Ad = request.Ad,
                    Soyad = request.Soyad,
                    Telefon = request.Telefon,
                    Daimi=request.Daimi,
                    Puan=request.Puan,
                    Mail=request.Mail
                };
                _context.musteri.Add(musteri);
                _context.SaveChanges();            
              
               return RedirectToAction("PuanSorgula");
            }   
            return View();
        }
        public IActionResult Puanmenu(int MasaID)
        {
            HttpContext.Session.SetInt32("MasaID", MasaID);
            var puanmenuList = _context.urunler.Where(u => u.puandurum == true);

            ViewBag.urunler = puanmenuList;
            TempData["MasaID"] = MasaID;    
            return View();
        }

        public IActionResult Sepetislem(int UrunID, int MasaID)
        {
            HttpContext.Session.SetInt32("MasaID", MasaID);
            var puanmenu = _context.urunler.FirstOrDefault(u => u.UrunID == UrunID);
            if (puanmenu == null)
            {
                return View("Error");
            }
            TempData["MasaID"] = MasaID;
            TempData["UrunID"] = UrunID;
            ViewBag.Masa = _context.masasayisi.FirstOrDefault(x => x.ID == MasaID)?.AD;

            return View(puanmenu);
        }
        [HttpPost]
        public IActionResult Sepetislem(int UrunID, int MasaID, int Adet, double Tutar)
        {
            string Telefon = HttpContext.Session.GetString("Telefon");
            var musteri = _context.musteri.FirstOrDefault(m => m.Telefon == Telefon);
            if (musteri == null)
            {
               
                return BadRequest("Belirtilen telefon numarasına ait müşteri bulunamadı.");
            }          
            int mevcutPuan = musteri.Puan.HasValue ? musteri.Puan.Value : 0;

            var puanmenu = _context.urunler.FirstOrDefault(u => u.UrunID == UrunID);

            if (puanmenu == null)
            {
                return View("Error");
            }

            sepet sepetim = new sepet();
            sepetim.urunlerID = UrunID;
            sepetim.IcerikID = 1;
            sepetim.Adet = Adet;
            sepetim.Tutar = 0;
            sepetim.MasaID= MasaID; 
            sepetim.TerminalID = 4;
            
            _context.Set<sepet>().Add(sepetim);
            _context.SaveChanges();

            //siparisler siparis = new siparisler();
            //siparis.urunlerID = UrunID;
            //siparis.TerminalID = 4;
            //siparis.MasaID = MasaID;
            //_context.Set<siparisler>().Add(siparis);
            //_context.SaveChanges();

            var urunPuan = puanmenu.Puan;
            var yeniPuan = mevcutPuan - urunPuan;

            musteri.Puan = yeniPuan;
            _context.SaveChanges();


            return RedirectToAction("PuanSorgula", new { UrunID = UrunID, masaID = MasaID });
        }
        public IActionResult EkleSepet(int UrunID)
        {
            var puanmenu = _context.urunler.FirstOrDefault(u => u.UrunID == UrunID);
            Models.sepet sepet = new sepet();
            if (puanmenu != null)
            {
                var seciliIcerikler = _context.icerik.ToList();
                sepet = new sepet
                {
                    urunlerID = UrunID,
                    Adet = sepet.Adet,
                    Tutar = sepet.Tutar,
                };
                _context.sepet.Add(sepet);
                _context.SaveChanges();
            }
            return RedirectToAction("Sepetim", new { UrunID = UrunID });
        }
        public IActionResult PuanSorgula()
        {
            var puanmenuList = _context.urunler.Where(u => u.puandurum == true);
            ViewBag.urunler = puanmenuList;

            return View();
        }

        [HttpPost]
        public IActionResult PuanSorgula(string Telefon)
        {
            if (string.IsNullOrEmpty(Telefon))
            {
                // Telefon numarası boş veya geçersizse hata mesajı gönder
                return BadRequest("Geçerli bir telefon numarası girmelisiniz.");
            }

            // Telefon numarasına göre veritabanında sorgulama yap
            var musteri = _context.GetMusteriByTelefon(Telefon);

            if (musteri == null)
            {
                // Telefon numarasına ait müşteri bulunamadıysa hata mesajı gönder
                return BadRequest("Belirtilen telefon numarasına ait müşteri bulunamadı.");
            }

            var puanmenuList = _context.urunler.Where(u => u.puandurum == true);
            var filteredPuanmenu = puanmenuList.Where(item => item.Puan <= musteri.Puan).ToList();
            ViewBag.urunler = filteredPuanmenu;

            // Telefon numarasına ait müşteri bilgilerini ViewModel olarak döndür
            var viewModel = new PuanSorgulaViewModel
            {
                Ad = musteri.Ad,
                SoyAd = musteri.Soyad,
                Puan = musteri.Puan
            };
            HttpContext.Session.SetString("Telefon", Telefon);

            return View("PuanSorgula", viewModel);
        }

    }
}