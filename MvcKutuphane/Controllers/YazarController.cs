using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace MvcKutuphane.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        DbMvcKutuphaneEntities1 db = new DbMvcKutuphaneEntities1();
        public ActionResult Index(int sayfa=1)
        {
            var sorgu = db.TBLYazar.ToList().ToPagedList(sayfa,4);
            return View(sorgu);
        }
        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YazarEkle(TBLYazar y)
        {
            db.TBLYazar.Add(y);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarSil(int id)
        {
            var sorgu = db.TBLYazar.Find(id);
            db.TBLYazar.Remove(sorgu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarGetir(int id)
        {
            var sorgu = db.TBLYazar.Find(id);
            return View(sorgu);
        }
        public ActionResult Guncelle(TBLYazar y)
        {
            var sorgu = db.TBLYazar.Find(y.YazarID);
            sorgu.YazarAd = y.YazarAd;
            sorgu.YazarSoyad = y.YazarSoyad;
            sorgu.YazarDetay = y.YazarDetay;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarKitapDetay(int id)
        { 
            var sorgu = db.TBLKitap.Where(p=>p.Yazar==id).ToList();
            return View(sorgu);
        }
    }
}