using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QRMENU.Models.Entity;

namespace QRMENU.Controllers
{
    public class GuvenlikController : Controller
    {
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
        public ActionResult Index(string GuncelSifre, string YeniSifre, string YeniSifreTekrar)
        {
            var kullanicilar = (string)Session["Mail"];
            var kullanici = db.Kullanicilar.FirstOrDefault(x => x.Mail == kullanicilar);

            // Güncel şifreyi kontrol et
            if (kullanici.Sifre == GuncelSifre)
            {
                // Yeni şifreleri kontrol et
                if (YeniSifre == YeniSifreTekrar)
                {
                    kullanici.Sifre = YeniSifre;
                    db.SaveChanges();
                    return View();
                }
                else
                {
                    ModelState.AddModelError("YeniSifreTekrar", "Yeni şifreler uyuşmuyor.");
                }
            }
            else
            {
                ModelState.AddModelError("GuncelSifre", "Güncel şifre yanlış.");
            }

            return View();
        }

    }
}