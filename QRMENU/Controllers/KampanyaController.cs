using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QRMENU.Models.Entity;
namespace QRMENU.Controllers
{
    public class KampanyaController : Controller
    {
        QRMenuEntities2 db = new QRMenuEntities2();
        // GET: Kampanya
        [Authorize]

        public ActionResult Index()
        {
            var kampanya = db.Kampanyalar.ToList();

            return View(kampanya);
        }



    }
}