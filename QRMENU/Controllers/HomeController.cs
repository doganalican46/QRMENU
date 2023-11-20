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

        QRMenuEntities1 db = new QRMenuEntities1();

        public ActionResult Index()
        {
            var dukkan = db.TBLDUKKAN.ToList();
            return View(dukkan);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Product()
        {
            var urunler = db.TBLURUNLER.ToList();
            return View(urunler);
        }

    }
}