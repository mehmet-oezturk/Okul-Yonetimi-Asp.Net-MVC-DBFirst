using mvcAdmingirisli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcAdmingirisli.Controllers
{
    public class OgrenciController : Controller
    {
        // GET: Ogrenci
        OgrencilerEntities db = new OgrencilerEntities();
   
        public ActionResult Index()
        {
            return View(db.Ogrenciler.ToList());
        }
        public ActionResult Yeni()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yeni(Ogrenciler ekle)
        {
            OgrencilerEntities db = new OgrencilerEntities();
            db.Ogrenciler.Add(ekle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Yenile(int id)
        {
            return View(db.Ogrenciler.Where(x => x.OgrenciNo == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Yenile(int id, Ogrenciler duzenle)
        {
            db.Entry(duzenle).State= System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View(db.Ogrenciler.Where(x => x.OgrenciNo == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, Ogrenciler sil)
        {
            sil = db.Ogrenciler.Where(x => x.OgrenciNo == id).FirstOrDefault();
            db.Ogrenciler.Remove(sil);
            db.SaveChanges();
            
            return RedirectToAction("Index");
        }
    }
}