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
    public class AyarlarController : Controller
    {
        DbMvcKutuphaneEntities1 db = new DbMvcKutuphaneEntities1();
        // GET: Ayarlar
        public ActionResult Index(int sayfa=1)
        {
            var sorgu = db.Admin.ToList().ToPagedList(sayfa,3);
            return View(sorgu);
        }
        [HttpPost]
        public ActionResult AdminEkle(Admin a)
        {
            db.Admin.Add(a);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }
        public ActionResult AdminDuzenle(int id)
        {
            var sorgu = db.Admin.Find(id);
            return View(sorgu);  
        }
        public ActionResult Guncelle(Admin g)
        {
            var sorgu = db.Admin.Find(g.ID);
            sorgu.Kulladi = g.Kulladi;
            sorgu.Sifre = g.Sifre;
            sorgu.Yetki = g.Yetki;
            sorgu.Resim = g.Resim;
            sorgu.Telefon = g.Telefon;
            sorgu.Mail=g.Mail;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var sorgu = db.Admin.Find(id);
            db.Admin.Remove(sorgu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}