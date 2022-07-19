using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class MesajlarController : Controller
    {
        // GET: Mesajlar
        DbMvcKutuphaneEntities1 db =new DbMvcKutuphaneEntities1(); 
        public ActionResult Index()
        {
            var uyemail = (string)Session["UyeMail"].ToString();    
            var mesajlar = db.TBLMesajlar.Where(p=>p.Alici==uyemail).ToList();
            
            return View(mesajlar);
        }
        [HttpPost]
        public ActionResult YeniMesaj(TBLMesajlar m)
        {
            db.TBLMesajlar.Add(m);
            db.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["UyeMail"];           
            var uye = db.TBLUyeler.FirstOrDefault(p => p.UyeMail == mail);
            return View();
        }
        public ActionResult GonderilenMesajlar()
        {
            var mail = (string)Session["UyeMail"];
            var gonderen = db.TBLMesajlar.Where(p => p.Gonderen == mail).ToList();        
          
            return View(gonderen);
        }
        public PartialViewResult MesajlarSidebar()
        {
            var mail = (string)Session["UyeMail"];
            var gidenmesajsayisi = db.TBLMesajlar.Where(p => p.Gonderen == mail).Count();
            ViewBag.gidenmesajsayisi = gidenmesajsayisi;
            var gelenmesajsayisi = db.TBLMesajlar.Where(p => p.Alici == mail).Count();
            ViewBag.gelenmesajsayisi = gelenmesajsayisi;
            return PartialView();
        }

        public ActionResult MesajDetay(int id)
        {           
            var sorgu = db.TBLMesajlar.Where(p => p.ID == id).ToList();
            return View(sorgu);
        }

        public ActionResult MesajDetay2(int id)
        {
            var sorgu = db.TBLMesajlar.Where(p => p.ID == id).ToList();
            return View(sorgu);
        }
        public ActionResult Sil(int id)
        {
            var sorgu = db.TBLMesajlar.Find(id);
            db.TBLMesajlar.Remove(sorgu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    } 
}