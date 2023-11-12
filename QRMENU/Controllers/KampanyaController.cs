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
        QRMenuEntities1 db = new QRMenuEntities1();
        // GET: Kampanya
        public ActionResult Index()
        {
            var kampanya = db.TBLKAMPANYALAR.ToList();
            return View(kampanya);
        }
    }
}