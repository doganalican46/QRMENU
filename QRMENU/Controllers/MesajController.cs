using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QRMENU.Models.Entity;
namespace QRMENU.Controllers
{
    public class MesajController : Controller
    {
        QRMenuEntities2 db = new QRMenuEntities2();
        // GET: Mesaj
        public ActionResult Index()
        {

            var mail = (string)Session["Mail"];

            var kullanici = db.Kullanicilar.FirstOrDefault(x => x.Mail == mail);

            if (kullanici != null)
            {
                var kullaniciid = kullanici.ID;

                var mesajlar = db.Mesajlar.Where(x => x.AliciID == kullaniciid).ToList();

                return View(mesajlar);
            }
            else
            {

                return RedirectToAction("UserNotFound");
            }
        }




        public ActionResult MesajSil(int id)
        {
            var mesaj = db.Mesajlar.Find(id);

            if (mesaj != null)
            {
                db.Mesajlar.Remove(mesaj);

                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        [Authorize]
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            List<SelectListItem> alicilar = (from i in db.Kullanicilar.Where(x => x.Rol == 0).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Ad,
                                                 Value = i.ID.ToString()

                                             }).ToList();
            ViewBag.alicilar = alicilar;


            var mail = (string)Session["Mail"];

            var kullanici = db.Kullanicilar.FirstOrDefault(x => x.Mail == mail);
            var kullaniciid = kullanici.ID;

            ViewBag.gonderenID = kullaniciid;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar k)
        {
            db.Mesajlar.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult YeniMesajGönder()
        {
            return View();
        }


        [HttpPost]
        public ActionResult YeniMesajGönder(int id, string Mesaj)
        {
            var Alici = db.Kullanicilar.Find(id);
            ViewBag.AliciAd = Alici.Ad + " " + Alici.Soyad;

            var mail = (string)Session["Mail"];
            var kullanici = db.Kullanicilar.FirstOrDefault(x => x.Mail == mail);
            var kullaniciid = kullanici.ID;
            ViewBag.gonderenID = kullaniciid;

            var yeniMesaj = new Mesajlar
            {
                AliciID = Alici.ID,
                GonderenID = kullaniciid,
                Mesaj = Mesaj,
                Tarih= DateTime.Now
            };
           

            db.Mesajlar.Add(yeniMesaj);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Gonderilenler()
        {
            var mail = (string)Session["Mail"];

            var kullanici = db.Kullanicilar.FirstOrDefault(x => x.Mail == mail);

            if (kullanici != null)
            {
                var kullaniciid = kullanici.ID;

                var mesajlar = db.Mesajlar.Where(x => x.GonderenID == kullaniciid).ToList();

                return View(mesajlar);
            }
            else
            {

                return RedirectToAction("UserNotFound");
            }
        }









    }
}