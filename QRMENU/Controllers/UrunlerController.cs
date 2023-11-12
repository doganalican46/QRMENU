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
    }
}