﻿using System;
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
        public ActionResult Index()
        {

            return View();
        }








    }
}