using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using QRMENU.Models.Entity;
namespace QRMENU.Controllers
{
    public class SuperAdminController : Controller
    {

        QRMenuEntities2 db = new QRMenuEntities2();
        // GET: SuperAdmin
        [Authorize]
        public ActionResult Index()
        {

            var kullanicilar = db.Kullanicilar.ToList();
            return View(kullanicilar);
        }
        [Authorize]
        [HttpGet]
        public ActionResult YeniKullanici()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult YeniKullanici(Kullanicilar k)
        {
            db.Kullanicilar.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KullaniciSil(int id)
        {
            var Kullanici = db.Kullanicilar.Find(id);
            Kullanici.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult KullaniciGetir(int id)
        {
            var Kullanici = db.Kullanicilar.Find(id);
            return View("KullaniciGetir", Kullanici);
        }
        [Authorize]
        public ActionResult KullaniciGuncelle(Kullanicilar k)
        {
            var Kullanici = db.Kullanicilar.Find(k.ID);
            Kullanici.TC = k.TC;
            Kullanici.Ad = k.Ad;
            Kullanici.Soyad = k.Soyad;
            Kullanici.Mail = k.Mail;
            Kullanici.Telefon = k.Telefon;
            Kullanici.DogumTarihi = k.DogumTarihi;
            Kullanici.Resim = k.Resim;
            Kullanici.Sifre = k.Sifre;
            Kullanici.Rol = k.Rol;

            Kullanici.Durum = k.Durum;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [Authorize]
        public ActionResult KullaniciDetay(int id)
        {
            var Kullanici = db.Kullanicilar.Find(id);
            var cafe = db.Cafeler.Where(h => h.KullaniciID == Kullanici.ID).ToList();

            ViewBag.Kullaniciadsoyad = Kullanici.Ad + " " + Kullanici.Soyad;
            ViewBag.Kullanicifotograf = Kullanici.Resim;
            ViewBag.Kullanicitelefon = Kullanici.Telefon;
            ViewBag.Kullanicimail = Kullanici.Mail;
            ViewBag.KullaniciID = Kullanici.ID;
            ViewBag.KullaniciDogumTar = Kullanici.DogumTarihi;
            ViewBag.Kullanicisifre = Kullanici.Sifre;
            ViewBag.Kullanicirol = Kullanici.Rol;

            var toplamCafe = db.Cafeler.Count(h => h.KullaniciID == Kullanici.ID);
            ViewBag.toplamCafe = toplamCafe;

            return View("KullaniciDetay", cafe);

        }


        public ActionResult AnaSayfa()
        {
            var mail = (string)Session["Mail"];
            var degerler = db.Kullanicilar.FirstOrDefault(x => x.Mail == mail);
            ViewBag.mail = mail;
            ViewBag.adsoyad = degerler.Ad + " " + degerler.Soyad;

            return View(degerler);
        }



        public ActionResult CafeRest()
        {
            var cafeler = db.Cafeler.ToList();
            
            return View(cafeler);
        }


        [Authorize]
        [HttpGet]
        public ActionResult YeniCafe()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult YeniCafe(Cafeler k)
        {
            db.Cafeler.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CafeSil(int id)
        {
            var cafe = db.Cafeler.Find(id);
            cafe.Durum = false;
            db.SaveChanges();
            return RedirectToAction("CafeRest");
        }


        [Authorize]
        public ActionResult CafeGetir(int id)
        {
            var cafe = db.Cafeler.Find(id);
            return View("CafeGetir", cafe);
        }

        [Authorize]
        public ActionResult CafeGuncelle(Cafeler k)
        {
            var cafe = db.Cafeler.Find(k.ID);

            cafe.Ad = k.Ad;
            cafe.Slogan = k.Slogan;
            cafe.Hakkinda = k.Hakkinda;
            cafe.Telefon = k.Telefon;
            cafe.Adres = k.Adres;
            cafe.KullaniciID = k.KullaniciID;

            cafe.Durum = k.Durum;
            db.SaveChanges();
            return RedirectToAction("CafeRest");
        }


        [Authorize]
        public ActionResult CafeDetay(int id)
        {
            var cafe = db.Cafeler.Find(id);

            if (cafe != null)
            {
                var kafeSahibi = db.Kullanicilar.Find(cafe.KullaniciID);

                if (kafeSahibi != null)
                {
                    ViewBag.KafeSahibi = kafeSahibi.Ad + " " + kafeSahibi.Soyad;
                    ViewBag.kafesahipid = kafeSahibi.ID;
                }
            }

            return View(new List<Cafeler> { cafe });
        }







        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }



    }
}