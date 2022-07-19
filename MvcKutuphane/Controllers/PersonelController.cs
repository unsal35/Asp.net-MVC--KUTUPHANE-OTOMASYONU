using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
namespace MvcKutuphane.Controllers
{
    public class PersonelController : Controller
    {
        DbMvcKutuphaneEntities1 db = new DbMvcKutuphaneEntities1();
        // GET: Personel
        public ActionResult Index()
        {
            var sorgu = db.TBLPersonel.ToList();
            return View(sorgu);
        }
        public ActionResult PersonelSil(int id)
        {
            var sorgu = db.TBLPersonel.Find(id);
            db.TBLPersonel.Remove(sorgu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            var sorgu = db.TBLPersonel.Find(id);
            return View(sorgu);
        }
        public ActionResult PersonelEkle(TBLPersonel p)
        {
            db.TBLPersonel.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Guncelle(TBLPersonel p)
        {
            var sorgu = db.TBLPersonel.Find(p.PersonelID);
            sorgu.Personel = p.Personel;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}