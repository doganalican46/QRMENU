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

    }
}