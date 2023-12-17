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
        QRMenuEntities2 db = new QRMenuEntities2();
        // GET: Admin

        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["KULLANICIMAIL"];
            var degerler = db.Kullanicilar.FirstOrDefault(x => x.Mail == mail);
            ViewBag.mail = mail;
            return View(degerler);
        }

    }
}