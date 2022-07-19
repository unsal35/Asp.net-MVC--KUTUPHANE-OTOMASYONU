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
    public class UyelerController : Controller
    {
        DbMvcKutuphaneEntities1 db = new DbMvcKutuphaneEntities1();
        // GET: Uyeler
        public ActionResult Index(int sayfa=1)
        {
            var sorgu = db.TBLUyeler.ToList().ToPagedList(sayfa,3);
            return View(sorgu);
        }
        public ActionResult UyeEkle(TBLUyeler u)
        {
            db.TBLUyeler.Add(u);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult UyeSil(int id)
        {
            var sorgu = db.TBLUyeler.Find(id);
            db.TBLUyeler.Remove(sorgu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeGetir(int id)
        {
            var sorgu = db.TBLUyeler.Find(id);
            return View(sorgu);
        }
        public ActionResult Guncelle(TBLUyeler u)
        {
            var sorgu = db.TBLUyeler.Find(u.UyeID);
            sorgu.UyeAd = u.UyeAd;
            sorgu.UyeSoyad = u.UyeSoyad;
            sorgu.UyeMail = u.UyeMail;
            sorgu.UyeKullaniciAdi = u.UyeKullaniciAdi;
            sorgu.UyeSifre = u.UyeSifre;
            sorgu.UyeTelefon = u.UyeTelefon;
            sorgu.UyeOkul = u.UyeOkul;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult UyeKitaplar(int id)
        {
            var sorgu = db.TBLHareket.Where(p => p.Uye == id).ToList();
            return View(sorgu);
        }
    }
}