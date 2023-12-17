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
        QRMenuEntities2 db = new QRMenuEntities2();

        [Authorize]

        // GET: QR
        public ActionResult Index()
        {
            return View();
        }
    }
}