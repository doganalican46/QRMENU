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
        QRMenuEntities1 db = new QRMenuEntities1();

        // GET: Kategori
        public ActionResult Index()
        {
            var kategori = db.TBLKATEGORILER.ToList();
            return View(kategori);
        }


        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }


        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORILER k1)
        {
            db.TBLKATEGORILER.Add(k1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}