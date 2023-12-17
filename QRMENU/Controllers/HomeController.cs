using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QRMENU.Models.Entity;

namespace QRMENU.Controllers
{
    public class HomeController : Controller
    {

        QRMenuEntities2 db = new QRMenuEntities2();

        public ActionResult Index()
        {
            var dukkan = db.Cafeler.ToList();
            return View(dukkan);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Product()
        {
            var urunler = db.Urunler.ToList();
            return View(urunler);
        }

    }
}