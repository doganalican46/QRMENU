using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QRMENU.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Urunler()
        {
            return View();
        }

        public ActionResult Kategoriler()
        {
            return View();
        }

        public ActionResult Kampanyalar()
        {
            return View();
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