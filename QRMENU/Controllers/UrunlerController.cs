using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QRMENU.Models.Entity;
namespace QRMENU.Controllers
{
    public class UrunlerController : Controller
    {
        QRMenuEntities2 db = new QRMenuEntities2();
        // GET: Urunler
        [Authorize]

        public ActionResult Index()
        {
            // Session üzerinden kullanıcının mail bilgisini alalım
            var mail = (string)Session["Mail"];

            // Kullanıcının cafesine ait menülerdeki ürünleri çekelim
            var urun = (from u in db.Urunler
                        join k in db.Kategoriler on u.KategoriID equals k.ID
                        join m in db.Menuler on k.MenuID equals m.ID
                        join c in db.Cafeler on m.CafeID equals c.ID
                        where c.Kullanicilar.Mail == mail
                        select u).ToList();

            return View(urun);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            // Session üzerinden kullanıcının mail bilgisini alalım
            var mail = (string)Session["Mail"];

            // Kullanıcının cafesine ait aktif menülerdeki kategorileri çekelim
            List<SelectListItem> degerler = (from c in db.Cafeler
                                             join m in db.Menuler on c.ID equals m.CafeID
                                             join k in db.Kategoriler on m.ID equals k.MenuID
                                             where c.Kullanicilar.Mail == mail && k.Durum == true
                                             select new SelectListItem
                                             {
                                                 Text = k.Ad,
                                                 Value = k.ID.ToString()
                                             }).ToList();

            ViewBag.kategoriler = degerler;
            return View();
        }




        [HttpPost]
        public ActionResult YeniUrun(Urunler u1)
        {
            var kategori = db.Kategoriler.Where(m => m.ID == u1.Kategoriler.ID).FirstOrDefault();
            u1.Kategoriler = kategori;
            db.Urunler.Add(u1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var urun = db.Urunler.Find(id);
            urun.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            var urun = db.Urunler.Find(id);
            List<SelectListItem> degerler = (from i in db.Kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Ad,
                                                 Value = i.ID.ToString()

                                             }).ToList();
            ViewBag.kategoriler = degerler;

            return View("UrunGetir", urun);
        }

        public ActionResult Guncelle(Urunler u1)
        {
            var urun = db.Urunler.Find(u1.ID);
            urun.Ad = u1.Ad;
            urun.Aciklama = u1.Aciklama;
            urun.Fiyat = u1.Fiyat;
            urun.Resim = u1.Resim;

            var kategori = db.Kategoriler.Where(m => m.ID == u1.Kategoriler.ID).FirstOrDefault();
            urun.KategoriID = kategori.ID;


            urun.Durum = u1.Durum;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}