using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class DuyurularController : Controller
    {
        DbMvcKutuphaneEntities1 db = new DbMvcKutuphaneEntities1();
        // GET: Duyurular

        public ActionResult Index()
        {
            var sorgu = db.TBLDuyurular.OrderByDescending(p=>p.ID).ToList();
            return View(sorgu);
        }
        [HttpPost]
        public ActionResult YeniDuyuruEkle(TBLDuyurular d)
        {
            db.TBLDuyurular.Add(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruSil(int id)
        {
            var sorgu = db.TBLDuyurular.Find(id);
            db.TBLDuyurular.Remove(sorgu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
     
        public ActionResult DuyuruDetay(int id)
        {
            var sorgu = db.TBLDuyurular.Find(id);
            return View(sorgu);
        }
        public ActionResult Guncelle(TBLDuyurular d)
        {
            var sorgu = db.TBLDuyurular.Find(d.ID);
            sorgu.kategori = d.kategori;
            sorgu.Icerik = d.Icerik;
            sorgu.Tarih = d.Tarih;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}