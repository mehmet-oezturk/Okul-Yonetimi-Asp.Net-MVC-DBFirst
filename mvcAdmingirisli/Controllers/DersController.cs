using mvcAdmingirisli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcAdmingirisli.Controllers
{
    public class DersController : Controller
    {
        // GET: Ders
        OgrencilerEntities db = new OgrencilerEntities();
     
        public ActionResult Index()
        {
            return View(db.Dersler.ToList());
        }
        public ActionResult Yeni()
        {
            List<SelectListItem> degerler = (from i in db.Hocalar.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Ad,
                                                 Value = i.HocaNo.ToString()
                                             }).ToList();
            ViewBag.dg = degerler;//combo box için oluşturduğumuz degerleri diğer sayfaya taşımak için kullnılan kalıp
            return View();
        }
        [HttpPost]
        public ActionResult Yeni(Dersler ekle)
        {
            OgrencilerEntities db = new OgrencilerEntities();
            var ktg = db.Hocalar.Where(m => m.HocaNo == ekle.Hocalar.HocaNo).FirstOrDefault();
            ekle.Hocalar = ktg;//kategoriden gelen değeri atar
            db.Dersler.Add(ekle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Yenile(int id)
        {
            
            //List<SelectListItem> degerler = (from i in db.Hocalar.ToList()
            //                                 select new SelectListItem
            //                                 {
            //                                     Text = i.Ad,
            //                                     Value = i.HocaNo.ToString()
            //                                 }).ToList();
            //ViewBag.dg = degerler;
            return View(db.Dersler.Where(x => x.DersNo == id).FirstOrDefault());

        }
        [HttpPost]
        public ActionResult Yenile(int id, Dersler duzenle)
        {
            //var ktg = db.Hocalar.Where(m => m.HocaNo == duzenle.Hocalar.HocaNo).FirstOrDefault();
            //duzenle.Hocalar = ktg;
          
            db.Entry(duzenle).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View(db.Dersler.Where(x => x.DersNo == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, Dersler sil)
        {
            sil = db.Dersler.Where(x => x.DersNo == id).FirstOrDefault();
            db.Dersler.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}