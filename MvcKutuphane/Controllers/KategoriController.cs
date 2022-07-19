using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
  
    public class KategoriController : Controller
    {
        DbMvcKutuphaneEntities1 Db = new DbMvcKutuphaneEntities1();
        // GET: Kategori
        public ActionResult Index()
        {
            var sorgu = Db.TBLKategori.ToList();
            return View(sorgu);
        }
       
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(TBLKategori k)
        {
            Db.TBLKategori.Add(k);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult KategoriFalse(int id)
        {
            var kategori = Db.TBLKategori.Find(id);
            kategori.KategoriDurum = false;
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriTrue(int id)
        {
            var kategori = Db.TBLKategori.Find(id);
            kategori.KategoriDurum = true;
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
           
            var sorgu = Db.TBLKategori.Find(id);
            return View(sorgu);
        }
        public ActionResult Guncelle(TBLKategori ktg)
        {

            var sorgu = Db.TBLKategori.Find(ktg.ID);
            sorgu.KategoriAd = ktg.KategoriAd;
            Db.SaveChanges();


            return RedirectToAction("Index");
        }
    }
}
