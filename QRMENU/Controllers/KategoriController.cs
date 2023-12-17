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
            var kategori = db.Kategoriler.ToList();
            return View(kategori);
        }


        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }


        [HttpPost]
        public ActionResult YeniKategori(Kategoriler k1)
        {
            db.Kategoriler.Add(k1);
            db.SaveChanges();
            return RedirectToAction("Index");
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