using Microsoft.AspNetCore.Authorization; // Authorize niteliğini ekleyin
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RestoranOtomasyonu.DAL;
using RestoranOtomasyonu.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace RestoranOtomasyonu.Areas.YönetimPaneli.Controllers
{
    [Authorize]
    [Area("YönetimPaneli")]
    public class AdminController : Controller
    {
        private readonly DataContext _context;
        public AdminController(DataContext context)
        {
            _context = context;
        }
          // Index işlemine sadece giriş yapmış olan kullanıcılar erişebilir

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> FileUpload(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                // Dosya yükleme işlemi burada gerçekleşir
                var fileName = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Başarılı yükleme mesajı veya başka işlemler yapılabilir
                ViewBag.Message = "Dosya başarıyla yüklendi.";
            }
            else
            {
                // Hata mesajı veya başka işlemler yapılabilir
                ViewBag.Message = "Dosya seçilmedi veya dosya boyutu sıfır.";
            }

            return View(); // FileUpload view yerine dilediğiniz başka bir view döndürebilirsiniz
        }


    }
}
