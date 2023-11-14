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
        QRMenuEntities1 db = new QRMenuEntities1();
        // GET: Urunler
        public ActionResult Index()
        {
            var urun = db.TBLURUNLER.ToList();
            return View(urun);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text=i.KATEGORIAD,
                                                 Value=i.KATEGORIID.ToString()

                                             }).ToList();
            ViewBag.kategoriler = degerler;
            return View();
        }


        [HttpPost]
        public ActionResult YeniUrun(TBLURUNLER u1)
        {
            var kategori = db.TBLKATEGORILER.Where(m => m.KATEGORIID == u1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            u1.TBLKATEGORILER = kategori;
            db.TBLURUNLER.Add(u1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var urun = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}