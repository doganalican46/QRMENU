using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QRMENU.Models.Entity;

namespace QRMENU.Controllers
{
    public class QRController : Controller
    {
        QRMenuEntities1 db = new QRMenuEntities1();

        [Authorize]

        // GET: QR
        public ActionResult Index()
        {
            return View();
        }
    }
}