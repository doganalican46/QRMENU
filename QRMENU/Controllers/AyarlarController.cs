using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QRMENU.Models.Entity;
namespace QRMENU.Controllers
{
    public class AyarlarController : Controller
    {
        QRMenuEntities2 db = new QRMenuEntities2();
        // GET: Ayarlar
        [Authorize]

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DukkanGetir(int id)
        {
            var dukkan = db.Cafeler.Find(id);
            return View("DukkanGetir", dukkan);
        }

        public ActionResult Guncelle(Cafeler u1)
        {
            var dukkan = db.Cafeler.Find(u1.ID);
            dukkan.Ad = u1.Ad;
            dukkan.Slogan = u1.Slogan;
            dukkan.Hakkinda = u1.Hakkinda;
            dukkan.Adres = u1.Adres;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}