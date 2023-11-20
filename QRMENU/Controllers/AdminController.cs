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

        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["KULLANICIMAIL"];
            var degerler = db.TBLKULLANICILAR.FirstOrDefault(x => x.KULLANICIMAIL == mail);
            ViewBag.mail = mail;
            return View(degerler);
        }

    }
}