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
            var mail = (string)Session["Mail"];

            var kampanyaProducts = (from kampanya in db.Kampanyalar
                                    join urun in db.Urunler on kampanya.ID equals urun.KampanyaID
                                    join kategori in db.Kategoriler on urun.KategoriID equals kategori.ID
                                    join menu in db.Menuler on kategori.MenuID equals menu.ID
                                    join cafe in db.Cafeler on menu.CafeID equals cafe.ID
                                    join kullanici in db.Kullanicilar on cafe.KullaniciID equals kullanici.ID
                                    where kullanici.Mail == mail
                                    select urun).ToList();

            return View(kampanyaProducts);
        }



    }
}