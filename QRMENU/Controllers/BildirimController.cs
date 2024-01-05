using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QRMENU.Models.Entity;
namespace QRMENU.Controllers
{
    public class BildirimController : Controller
    {
        QRMenuEntities2 db = new QRMenuEntities2();
        // GET: Bildirim
        public ActionResult Index()
        {
            var bildirim = db.Bildirimler.ToList();
            return View(bildirim);
        }

        [Authorize]
        [HttpGet]
        public ActionResult YeniBildirim()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult YeniBildirim(Bildirimler k)
        {
            k.Tarih = DateTime.Now;
            db.Bildirimler.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BildirimSil(int id)
        {
            var Bildirim = db.Bildirimler.Find(id);
            Bildirim.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult BildirimGetir(int id)
        {
            var Bildirim = db.Bildirimler.Find(id);
            return View("BildirimGetir", Bildirim);
        }
        [Authorize]
        public ActionResult BildirimGuncelle(Bildirimler k)
        {
            var Bildirim = db.Bildirimler.Find(k.ID);
            Bildirim.Baslik = k.Baslik;
            Bildirim.Icerik= k.Icerik;
            Bildirim.Fotograf= k.Fotograf;
            Bildirim.Durum = k.Durum;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}