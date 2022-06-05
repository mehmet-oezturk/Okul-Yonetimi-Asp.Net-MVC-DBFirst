using mvcAdmingirisli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcAdmingirisli.Controllers
{
    public class HocaController : Controller
    {
        // GET: Hoca
        OgrencilerEntities db = new OgrencilerEntities();

        public ActionResult Index()
        {
            return View(db.Hocalar.ToList());
        }
        public ActionResult Yeni()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yeni(Hocalar ekle)
        {
            OgrencilerEntities db = new OgrencilerEntities();
            db.Hocalar.Add(ekle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Yenile(int id)
        {
            return View(db.Hocalar.Where(x => x.HocaNo == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Yenile(int id, Hocalar duzenle)
        {
            db.Entry(duzenle).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View(db.Hocalar.Where(x => x.HocaNo == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, Hocalar sil)
        {
            sil = db.Hocalar.Where(x => x.HocaNo == id).FirstOrDefault();
            db.Hocalar.Remove(sil);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}