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
        QRMenuEntities1 db = new QRMenuEntities1();
        // GET: Ayarlar
        [Authorize]

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DukkanGetir(int id)
        {
            var dukkan = db.TBLDUKKAN.Find(id);
            return View("DukkanGetir", dukkan);
        }

        public ActionResult Guncelle(TBLDUKKAN u1)
        {
            var dukkan = db.TBLDUKKAN.Find(u1.DUKKANID);
            dukkan.DUKKANAD = u1.DUKKANAD;
            dukkan.DUKKANSLOGAN = u1.DUKKANSLOGAN;
            dukkan.DUKKANHAKKINDA = u1.DUKKANHAKKINDA;
            dukkan.DUKKANADRES = u1.DUKKANADRES;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}