using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QRMENU.Models.Entity;
namespace QRMENU.Controllers
{
    public class ProfilController : Controller
    {
        // GET: Profil
        QRMenuEntities2 db = new QRMenuEntities2();

        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            var mail = (string)Session["Mail"];
            var degerler = db.Kullanicilar.FirstOrDefault(x => x.Mail == mail);

            return View(degerler);
        }

        [HttpPost]
        public ActionResult Index(Kullanicilar k)
        {
            if (ModelState.IsValid)
            {
                var kullanicilar = (string)Session["Mail"];
                var kullanici = db.Kullanicilar.FirstOrDefault(x => x.Mail == kullanicilar);

                kullanici.Ad = k.Ad;
                kullanici.Soyad = k.Soyad;
                kullanici.DogumTarihi = k.DogumTarihi;


                db.SaveChanges();
                return View();
            }
            else
            {
                return View(k);
            }
        }


        [HttpPost]
        public ActionResult ProfilResmiYukle(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                if (file.ContentType == "image/jpeg" || file.ContentType == "image/jpg" || file.ContentType == "image/png")
                {
                    if (file.ContentLength <= 5 * 1024 * 1024) // 5 MB'dan küçükse
                    {
                        // Dosyayı kaydet veya işle
                        var fileName = Path.GetFileName(file.FileName);

                        // Klasörü kontrol et ve oluştur
                        var uploadPath = Server.MapPath("~/Uploads");
                        if (!Directory.Exists(uploadPath))
                        {
                            Directory.CreateDirectory(uploadPath);
                        }

                        var path = Path.Combine(uploadPath, fileName);
                        file.SaveAs(path);

                        // Profil resmini güncelle
                        Session["Resim"] = "/Uploads/" + fileName;

                        // Kullanıcının veritabanındaki profil resmini güncelle
                        var kullanicilar = (string)Session["Mail"];
                        var kullanici = db.Kullanicilar.FirstOrDefault(x => x.Mail == kullanicilar);
                        kullanici.Resim = "/Uploads/" + fileName; // "Resim" sütunu adınız neyse ona göre düzenleyin

                        db.SaveChanges();
                    }
                    else
                    {
                        ModelState.AddModelError("file", "Dosya 5 MB'dan büyük olamaz.");
                    }
                }
                else
                {
                    ModelState.AddModelError("file", "Geçersiz dosya türü. Sadece JPG ve PNG kabul edilir.");
                }
            }
            else
            {
                ModelState.AddModelError("file", "Dosya seçilmedi.");
            }

            // Geri dön veya başka bir sayfaya yönlendir
            return RedirectToAction("Index");
        }



    }
}
