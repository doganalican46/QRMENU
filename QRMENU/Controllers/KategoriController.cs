using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QRMENU.Models.Entity;

namespace QRMENU.Controllers
{
    public class KategoriController : Controller
    {
        QRMenuEntities2 db = new QRMenuEntities2();

        // GET: Kategori
        [Authorize]

        public ActionResult Index()
        {
            var mail = (string)Session["Mail"];

            var kategoriler = (from k in db.Kategoriler
                               join m in db.Menuler on k.MenuID equals m.ID
                               join c in db.Cafeler on m.CafeID equals c.ID
                               where c.Kullanicilar.Mail == mail
                               select k).ToList();

            return View(kategoriler);
        }



        [HttpGet]
        public ActionResult YeniKategori()
        {
            var mail = (string)Session["Mail"];

            List<SelectListItem> degerler = (from c in db.Cafeler
                                             join m in db.Menuler on c.ID equals m.CafeID
                                             where c.Kullanicilar.Mail == mail && m.Durum == true
                                             select new SelectListItem
                                             {
                                                 Text = m.Ad,
                                                 Value = m.ID.ToString()
                                             }).ToList();

            ViewBag.menuler = degerler;
            return View();
        }


        [HttpPost]
        public ActionResult YeniKategori(Kategoriler k1)
        {
            var menuId = k1.MenuID; // Assuming MenuID is a property in Kategoriler class
            var menu = db.Menuler.FirstOrDefault(m => m.ID == menuId);

            if (menu != null)
            {
                k1.Menuler = menu;
                db.Kategoriler.Add(k1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                // Handle the case where the menu is not found
                // You might want to display an error message or redirect to an error page.
                return View("Error");
            }
        }



        public ActionResult KategoriSil(int id)
        {

            var kategori = db.Kategoriler.Find(id);

            var urunler = db.Urunler.Where(u => u.KategoriID == id);
            foreach (var urun in urunler)
            {
                urun.Ad = null;
            }

            db.Kategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");


        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.Kategoriler.Find(id);
            return View("KategoriGetir", kategori);
        }


        public ActionResult Guncelle(Kategoriler k1)
        {
            var kategori = db.Kategoriler.Find(k1.ID);
            kategori.Ad = k1.Ad;
            kategori.Durum = k1.Durum;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}