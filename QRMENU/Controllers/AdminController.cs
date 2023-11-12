using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QRMENU.Models.Entity;
namespace QRMENU.Controllers
{
    public class AdminController : Controller
    {
        QRMenuEntities1 db = new QRMenuEntities1();
        // GET: Admin
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Urunler()
        {
            var urun = db.TBLURUNLER.ToList();
            return View(urun);
        }

        public ActionResult Kategoriler()
        {
            var kategori = db.TBLKATEGORILER.ToList();
            return View(kategori);
        }

        public ActionResult Kampanyalar()
        {
            var kampanya = db.TBLKAMPANYALAR.ToList();
            return View(kampanya);
        }

        public ActionResult Profil()
        {
            return View();
        }

        public ActionResult Guvenlik()
        {
            return View();
        }
        public ActionResult Ayarlar()
        {
            return View();
        }


    }
}