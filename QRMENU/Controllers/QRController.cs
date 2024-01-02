using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QRMENU.Models.Entity;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace QRMENU.Controllers
{
    public class QRController : Controller
    {
        QRMenuEntities2 db = new QRMenuEntities2();

        [Authorize]

        // GET: QR

        public ActionResult Index()
        {
            var mail = (string)Session["Mail"];

            var qrKodlar = (from m in db.Menuler
                            join c in db.Cafeler on m.CafeID equals c.ID
                            join qr in db.QR on m.ID equals qr.MenuID
                            where c.Kullanicilar.Mail == mail
                            select qr.MenuID).ToList();

            return View(qrKodlar);
        }



        [HttpGet]
        public ActionResult YeniQR()
        {
            // Session üzerinden kullanıcının mail bilgisini alalım
            var mail = (string)Session["Mail"];

            // Kullanıcının cafesine ait aktif menülerdeki ürünleri çekelim
            List<SelectListItem> degerler = (from c in db.Cafeler
                                             join m in db.Menuler on c.ID equals m.CafeID
                                             where c.Kullanicilar.Mail == mail
                                             select new SelectListItem
                                             {
                                                 Text = m.Ad,
                                                 Value = m.ID.ToString()
                                             }).ToList();

            ViewBag.menuler = degerler;
            return View();
        }


        [HttpPost]
        public ActionResult YeniQR(QR qr)
        {
            var menu = db.Menuler.FirstOrDefault(m => m.ID == qr.MenuID);

            if (menu != null)
            {
                db.QR.Add(qr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }

        public ActionResult QRSil(int id)
        {
            var qr = db.QR.Find(id);
            qr.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}