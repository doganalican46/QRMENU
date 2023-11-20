using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QRMENU.Controllers
{
    public class GuvenlikController : Controller
    {
        // GET: Guvenlik
        [Authorize]

        public ActionResult Index()
        {
            return View();
        }
    }
}