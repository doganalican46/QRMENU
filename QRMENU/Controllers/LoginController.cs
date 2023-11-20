using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using QRMENU.Models.Entity;
namespace QRMENU.Controllers
{
    public class LoginController : Controller
    {
        QRMenuEntities1 db = new QRMenuEntities1();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(TBLKULLANICILAR k)
        {
            db.TBLKULLANICILAR.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult LoginUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUser(TBLKULLANICILAR log)
        {
            var login = db.TBLKULLANICILAR.FirstOrDefault(x => x.KULLANICIMAIL == log.KULLANICIMAIL && x.KULLANICISIFRE == log.KULLANICISIFRE);

            if (login != null)
            {
                FormsAuthentication.SetAuthCookie(login.KULLANICIMAIL, false);
                Session["KULLANICIMAIL"] = login.KULLANICIMAIL.ToString();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


    }
}