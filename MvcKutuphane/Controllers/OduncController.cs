using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
   
    public class OduncController : Controller
    {
        DbMvcKutuphaneEntities1 db = new DbMvcKutuphaneEntities1();
        // GET: Odunc
        public ActionResult Index()
        {
            var sorgu = db.TBLHareket.Where(p => p.IslemDurum == false).ToList();
            return View(sorgu);
        }
        [HttpGet]
        public ActionResult OduncVer()
        {
            List<SelectListItem> Uyeler = (from i in db.TBLUyeler.ToList()
                                           select new SelectListItem
                                           {
                                               Value = i.UyeID.ToString(),
                                               Text = i.UyeAd

                                           }).ToList();
            ViewBag.Uyeler = Uyeler;
            List<SelectListItem> Kitaplar = (from j in db.TBLKitap.Where(a=>a.Durum==true).ToList()
                                             select new SelectListItem
                                             {
                                                 Value = j.KitapID.ToString(),
                                                 Text = j.KitapAd
                                             }).ToList();
            ViewBag.Kitaplar = Kitaplar;
            List<SelectListItem> Personel = (from p in db.TBLPersonel.ToList()
                                             select new SelectListItem { 
                                             Value=p.PersonelID.ToString(),
                                             Text=p.Personel
                                             }).ToList();
            ViewBag.Personel=Personel;
            return View();

        }
        [HttpPost]
        public ActionResult OduncVer(TBLHareket h)
        {
            db.TBLHareket.Add(h);
            db.SaveChanges();
            return RedirectToAction("Index", "Kitap");




        }
        public ActionResult OduncIade(TBLHareket h)
        {
            var odn = db.TBLHareket.Find(h.ID);
            DateTime d1 = DateTime.Parse(odn.IadeTarihi.ToString());
            DateTime d2 = DateTime.Parse(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.sure = d3.TotalDays;

            return View(odn);
        }
        public ActionResult Guncelle(TBLHareket h)
        {
            var sorgu = db.TBLHareket.Find(h.ID);
            sorgu.UyeGetirTarih = h.UyeGetirTarih;
            sorgu.IslemDurum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}