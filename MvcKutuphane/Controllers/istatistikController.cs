using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class istatistikController : Controller
    {
        DbMvcKutuphaneEntities1 db = new DbMvcKutuphaneEntities1 ();
        // GET: istatistik
        public ActionResult Index()
        {
            var uyeler = db.TBLUyeler.Count();
            ViewBag.uyeler = uyeler;
            var kitap = db.TBLKitap.Count();
            ViewBag.kitap = kitap;
            var hareket = db.TBLKitap.Where(p=>p.Durum==false).Count();
            ViewBag.hareket = hareket;
            var ceza = db.TBLCezalar.Sum(p=>p.Para);
            ViewBag.ceza = ceza;
            return View();
        }
        public ActionResult Hava()
        {          
            return View();
        }
        public ActionResult Galeri()
        {
            var sorgu = db.TBLGaleri.ToList();
            return View(sorgu);
        }
        [HttpPost]
        public ActionResult ResimYukle(TBLGaleri dosya)
        {
            db.TBLGaleri.Add(dosya);
            db.SaveChanges();
            return RedirectToAction("Galeri");

        }
        public ActionResult Kartlar()
        {
            var kitapsayisi = db.TBLKitap.Count();
            ViewBag.kitapsayisi = kitapsayisi;
            var uyesayisi = db.TBLUyeler.Count();
            ViewBag.Uyesayisi = uyesayisi;
            var kasatutar = db.TBLCezalar.Sum(p => p.Para);
            ViewBag.kasatutar = kasatutar;
            var odunckitap = db.TBLHareket.Where(p => p.IslemDurum == false).Count();
            ViewBag.odunckitap = odunckitap;
            var kategorisayisi = db.TBLKategori.Count();
            ViewBag.kategorisayisi = kategorisayisi;
            var enfazlakitapyazar = db.EnFazlaKitapYazar().FirstOrDefault();
            ViewBag.enfazlakitapyazar = enfazlakitapyazar;
            var eniyiyayinevi = db.TBLKitap.GroupBy(p => p.YayinEvi).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.eniyiyayinevi = eniyiyayinevi;
            var aktifuye = db.TBLHareket.GroupBy(p => p.TBLUyeler.UyeAd).OrderByDescending(y => y.Count()).Select(x =>  x.Key ).FirstOrDefault();
            ViewBag.aktifuye = aktifuye;
            var encokokunankitap = db.TBLHareket.GroupBy(p => p.TBLKitap.KitapAd).OrderByDescending(y => y.Count()).Select(x => x.Key).FirstOrDefault();
            ViewBag.encokokunankitap = encokokunankitap;
            var enbasarilipersonel = db.TBLHareket.GroupBy(p => p.TBLPersonel.Personel).OrderByDescending(y => y.Count()).Select(x => x.Key).FirstOrDefault();
            ViewBag.enbasarilipersonel = enbasarilipersonel;
            var mesajsayisi = db.TBLiletisim.Count();
            ViewBag.mesajsayisi = mesajsayisi;
            var tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            var kitapdurum = db.TBLHareket.OrderByDescending(a=>a.ID).Where(p => p.AlisTarihi == tarih).Select(x=>x.TBLKitap.KitapAd).FirstOrDefault();
            ViewBag.kitapdurum = kitapdurum;
            return View();
        }
  

    }
}