//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using QRMENU.Models.Entity;
//namespace QRMENU.Controllers
//{
//    public class KampanyaController : Controller
//    {
//        QRMenuEntities2 db = new QRMenuEntities2();
//        // GET: Kampanya
//        [Authorize]

//        public ActionResult Index()
//        {
//            var kampanya = db.Kampanyalar.ToList();
            
//            return View(kampanya);
//        }

//        [HttpGet]
//        public ActionResult YeniKampanya()
//        {
//            List<SelectListItem> degerler = (from i in db.Urunler.ToList()
//                                             select new SelectListItem
//                                             {
//                                                 Text = i.Ad,
//                                                 Value = i.ID.ToString()

//                                             }).ToList();
//            ViewBag.urunler = degerler;


//            return View();
//        }


//        [HttpPost]
//        public ActionResult YeniKampanya(Kampanyalar k1)
//        {
//            var urun = db.Urunler.Where(m => m.ID == k1.Urunler.ID).FirstOrDefault();
//            k1.Urunler = urun;

//            db.Kampanyalar.Add(k1);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        public ActionResult KampanyaSil(int id)
//        {
//            var kampanya = db.Kampanyalar.Find(id);
//            db.Kampanyalar.Remove(kampanya);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        public ActionResult KampanyaGetir(int id)
//        {
//            List<SelectListItem> degerler = (from i in db.Urunler.ToList()
//                                             select new SelectListItem
//                                             {
//                                                 Text = i.Ad,
//                                                 Value = i.ID.ToString()

//                                             }).ToList();
//            ViewBag.urunler = degerler;
//            var kampanya = db.Kampanyalar.Find(id);
//            return View("KampanyaGetir", kampanya);
//        }


//        //public ActionResult Guncelle(Kampanyalar k1)
//        //{
//        //    var kampanya = db.Kampanyalar.Find(k1.ID);
//        //    kampanya.Aciklama = k1.Aciklama;

//        //    var urun = db.Urunler.Where(m => m.ID == k1.Urunler.Ad).FirstOrDefault();
//        //    kampanya = urun.URUNID;


//        //    kampanya.Durum = k1.Durum;
//        //    db.SaveChanges();
//        //    return RedirectToAction("Index");
//        //}
//    }
//}