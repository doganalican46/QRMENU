using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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
            var mail = (string)Session["Mail"];
            var degerler = db.Kullanicilar.FirstOrDefault(x => x.Mail == mail);
            ViewBag.mail = mail;

            return View(degerler);
        }

        public ActionResult GelenKutusu()
        {
            var mail = (string)Session["Mail"];

            var kullanici = db.Kullanicilar.FirstOrDefault(x => x.Mail == mail);

            if (kullanici != null)
            {
                var kullaniciid = kullanici.ID;

                var mesajlar = db.Mesajlar.Where(x => x.AliciID == kullaniciid).ToList();

                return View(mesajlar);
            }
            else
            {

                return RedirectToAction("UserNotFound");
            }
        }


        public ActionResult MesajGonder()
        {

            return View();
        }

        public ActionResult MesajSil(int id)
        {
            var mesaj = db.Mesajlar.Find(id);

            if (mesaj != null)
            {
                db.Mesajlar.Remove(mesaj);

                db.SaveChanges();
            }

            return RedirectToAction("GelenKutusu");
        }
        


    public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Login");
        }


    }
}