using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QRMENU.Models.Entity;
namespace QRMENU.Controllers
{
    public class KampanyaController : Controller
    {
        QRMenuEntities1 db = new QRMenuEntities1();
        // GET: Kampanya
        [Authorize]

        public ActionResult Index()
        {
            var kampanya = db.TBLKAMPANYALAR.ToList();
            return View(kampanya);
        }

        [HttpGet]
        public ActionResult YeniKampanya()
        {
            List<SelectListItem> degerler = (from i in db.TBLURUNLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.URUNAD,
                                                 Value = i.URUNID.ToString()

                                             }).ToList();
            ViewBag.urunler = degerler;
            return View();
        }


        [HttpPost]
        public ActionResult YeniKampanya(TBLKAMPANYALAR k1)
        {
            var urun = db.TBLURUNLER.Where(m => m.URUNID == k1.TBLURUNLER.URUNID).FirstOrDefault();
            k1.TBLURUNLER = urun;

            db.TBLKAMPANYALAR.Add(k1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KampanyaSil(int id)
        {
            var kampanya = db.TBLKAMPANYALAR.Find(id);
            db.TBLKAMPANYALAR.Remove(kampanya);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KampanyaGetir(int id)
        {
            List<SelectListItem> degerler = (from i in db.TBLURUNLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.URUNAD,
                                                 Value = i.URUNID.ToString()

                                             }).ToList();
            ViewBag.urunler = degerler;
            var kampanya = db.TBLKAMPANYALAR.Find(id);
            return View("KampanyaGetir", kampanya);
        }


        public ActionResult Guncelle(TBLKAMPANYALAR k1)
        {
            var kampanya = db.TBLKAMPANYALAR.Find(k1.KAMPANYAID);
            kampanya.KAMPANYAACIKLAMA = k1.KAMPANYAACIKLAMA;

            var urun = db.TBLURUNLER.Where(m => m.URUNID == k1.TBLURUNLER.URUNID).FirstOrDefault();
            kampanya.KAMPANYALIURUN = urun.URUNID;


            kampanya.KAMPANYASURESI = k1.KAMPANYASURESI;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}