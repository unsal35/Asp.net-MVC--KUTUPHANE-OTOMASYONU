using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using PagedList.Mvc;
using PagedList;
namespace MvcKutuphane.Controllers
{
    public class KitapController : Controller
    {
        DbMvcKutuphaneEntities1 db = new DbMvcKutuphaneEntities1();
        // GET: Kitap
        public ActionResult Index(string p)
        {
            var kitaplar = from k in db.TBLKitap select k;
            if (!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(a => a.KitapAd.Contains(p));
            }
           
            return View(kitaplar.ToList());
        }
        public ActionResult KitapSil(int id)
        {
            var sorgu = db.TBLKitap.Find(id);
            db.TBLKitap.Remove(sorgu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> kitapkategori = (from i in db.TBLKategori.Where(p=>p.KategoriDurum==true).ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = i.KategoriAd,
                                                      Value = i.ID.ToString()
                                                  }).ToList();
            ViewBag.kitapkategori = kitapkategori;
            List<SelectListItem> KitapYazar = (from a in db.TBLYazar.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = a.YazarAd,
                                                   Value = a.YazarID.ToString()
                                               }).ToList();
            ViewBag.KitapYazar = KitapYazar;
            return View();
           
        }
        [HttpPost]
        public ActionResult KitapEkle(TBLKitap k)
        {
            var kategoricek = db.TBLKategori.Where(p => p.ID == k.TBLKategori.ID).FirstOrDefault();
            var yazarcek = db.TBLYazar.Where(p => p.YazarID == k.TBLYazar.YazarID).FirstOrDefault();
            k.TBLKategori = kategoricek;
            k.TBLYazar = yazarcek;
            db.TBLKitap.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapGetir(int id)
        {
          
            var sorgu = db.TBLKitap.Find(id);
            List<SelectListItem> KitapYazar = (from a in db.TBLYazar.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = a.YazarAd,
                                                   Value = a.YazarID.ToString()
                                               }).ToList();
            ViewBag.KitapYazar = KitapYazar;
            List<SelectListItem> KitapKategori = (from item in db.TBLKategori.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = item.KategoriAd,
                                                      Value = item.ID.ToString()
                                                  }
                                         ).ToList();
            ViewBag.KitapKategori = KitapKategori;
            return View(sorgu);
        }

        public ActionResult Guncelle(TBLKitap k)
        {
          
            var sorgu = db.TBLKitap.Find(k.KitapID);
            sorgu.KitapAd = k.KitapAd;
            sorgu.BasimYil = k.BasimYil;
            sorgu.YayinEvi = k.YayinEvi;
            sorgu.SayfaSayisi = k.SayfaSayisi;
            sorgu.Kategori = k.TBLKategori.ID;
            sorgu.Yazar = k.TBLYazar.YazarID;
            sorgu.Durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}