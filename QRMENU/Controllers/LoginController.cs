﻿using System;
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


        QRMenuEntities2 db = new QRMenuEntities2();
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
        public ActionResult Register(Kullanicilar k)
        {
            db.Kullanicilar.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult LoginUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUser(Kullanicilar log)
        {
            var login = db.Kullanicilar.FirstOrDefault(x => x.Mail == log.Mail && x.Sifre == log.Sifre);

            if (login != null)
            {
                FormsAuthentication.SetAuthCookie(login.Mail, false);
                Session["Mail"] = login.Mail.ToString();
                Session["AdSoyad"] = login.Ad + " " + login.Soyad;
                Session["Sifre"] = login.Sifre;
                Session["Resim"] = login.Resim;

                if (login.Rol == 0)
                {
                    var bildirimler = db.Bildirimler.ToList();
                    TempData["Bildirimler"] = bildirimler;

                    return RedirectToAction("Index", "Admin");
                }
                else if (login.Rol == 1)
                {
                    return RedirectToAction("AnaSayfa", "SuperAdmin");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }



    }
}