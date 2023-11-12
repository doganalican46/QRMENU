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
        public ActionResult Index()
        {
            return View();
        }
    }
}