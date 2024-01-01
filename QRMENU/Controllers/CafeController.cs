using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QRMENU.Models.Entity;
namespace QRMENU.Controllers
{
    public class CafeController : Controller
    {
        QRMenuEntities2 db = new QRMenuEntities2();
        [Authorize]
        // GET: Cafe
        public ActionResult Index()
        {
            var mail = (string)Session["Mail"];

            var user = db.Kullanicilar.FirstOrDefault(x => x.Mail == mail);

            if (user != null)
            {
                var cafes = db.Cafeler.Where(c => c.KullaniciID == user.ID).ToList();

                return View(cafes);
            }

            return View("Error");
        }

        [Authorize]
        [HttpGet]
        public ActionResult YeniCafe()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult YeniCafe(Cafeler u1)
        {
            var mail = (string)Session["Mail"];

            var user = db.Kullanicilar.FirstOrDefault(x => x.Mail == mail);

            if (user != null)
            {
                u1.KullaniciID = user.ID;

                db.Cafeler.Add(u1);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View("Error");
        }


        public ActionResult CafeGetir(int id)
        {
            var cafe = db.Cafeler.Find(id);
            return View("CafeGetir", cafe);
        }


        public ActionResult Guncelle(Cafeler u1)
        {
            var cafe = db.Cafeler.Find(u1.ID);
            cafe.Ad = u1.Ad;
            cafe.Slogan = u1.Slogan;
            cafe.Hakkinda = u1.Hakkinda;
            cafe.Adres = u1.Adres;
            cafe.Telefon = u1.Telefon;

            cafe.Durum = u1.Durum;
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult CafeSil(int id)
        {
            var cafe = db.Cafeler.Find(id);
            cafe.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Saat()
        {
            return View();
        }


        public ActionResult CafeSosyalMedya(int id)
        {
            var cafe = db.Cafeler.Find(id);

            if (cafe != null)
            {
                ViewBag.cafeid = cafe.ID;

                var socialMedias = cafe.SosyalMedyalar.ToList();

                return View("CafeSosyalMedya", socialMedias);
            }

            return View("Error");
        }



        [HttpGet]
        public ActionResult YeniSosyalMedya(int id)
        {
            var cafe = db.Cafeler.Find(id);
            ViewBag.cafeid = cafe.ID;

            return View();
        }

        [HttpPost]
        public ActionResult YeniSosyalMedya(SosyalMedyalar yeniSosyalMedya)
        {
  
            db.SosyalMedyalar.Add(yeniSosyalMedya);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult SosyalMedyaSil(int id)
        {
            var sosyal = db.SosyalMedyalar.Find(id);
            sosyal.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }




        public ActionResult SosyalMedyaGetir(int id)
        {
            var sosyal = db.SosyalMedyalar.Find(id);
            return View("SosyalMedyaGetir", sosyal);
        }


        public ActionResult SosyalMedyaGuncelle(SosyalMedyalar u1)
        {
            var sosyal = db.SosyalMedyalar.Find(u1.ID);
            sosyal.Ad = u1.Ad;
            sosyal.Link = u1.Link;
            sosyal.Durum = u1.Durum;
            db.SaveChanges();
            return RedirectToAction("Index");
        }






    }
}