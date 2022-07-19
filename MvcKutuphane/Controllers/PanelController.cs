using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using System.Web.Security;

namespace MvcKutuphane.Controllers
{

    public class PanelController : Controller
    {
        DbMvcKutuphaneEntities1 db = new DbMvcKutuphaneEntities1();
        // GET: Panel
        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            var mail = (string)Session["UyeMail"];
            //var uye = db.TBLUyeler.FirstOrDefault(x => x.UyeMail == mail);
            var uye = db.DuyurularAylik().OrderByDescending(p=>p.Tarih).ToList();
            var uyead = db.TBLUyeler.Where(p => p.UyeMail == mail).Select(x => x.UyeAd).FirstOrDefault();
            ViewBag.uyead = uyead;
            var uyesoyad = db.TBLUyeler.Where(a => a.UyeMail == mail).Select(y => y.UyeSoyad).FirstOrDefault();
            ViewBag.uyesoyad = uyesoyad;
            var uyeresim = db.TBLUyeler.Where(b => b.UyeMail == mail).Select(z => z.UyeFotograf).FirstOrDefault();
            ViewBag.uyeresim = uyeresim;
            var uyeokul = db.TBLUyeler.Where(b => b.UyeMail == mail).Select(z => z.UyeOkul).FirstOrDefault();
            ViewBag.uyeokul = uyeokul;
            var uyetelefon = db.TBLUyeler.Where(b => b.UyeMail == mail).Select(z => z.UyeTelefon).FirstOrDefault();
            ViewBag.uyetelefon = uyetelefon;
           //giriş yapan uyenin id değerini yakaladık daha sonra hareket tablosunda bu uye id kaç kere var onu sorguladık aldığı kitap sayısını bulduk
            var uyeid = db.TBLUyeler.Where(c => c.UyeMail == mail).Select(n => n.UyeID).FirstOrDefault();
            var kitapsayisi = db.TBLHareket.Where(x => x.Uye == uyeid).Count();
            ViewBag.kitapsayisi = kitapsayisi;
          //üyenin son aldığı kitabın adını çekme
            var sonkitap = db.TBLHareket.Where(c => c.Uye == uyeid).OrderByDescending(a => a.AlisTarihi).Select(x => x.TBLKitap.KitapAd).FirstOrDefault();
            ViewBag.sonkitap = sonkitap;
            //toplam gönderdiği mesaj sayısı
            var mesajsayi=db.TBLMesajlar.Where(x=>x.Gonderen==mail).Count();
            ViewBag.mesajsayi = mesajsayi;
            return View(uye);
        } 
        [HttpPost]
        //Profili düzenleme 
        public ActionResult Index(TBLUyeler u)
        {
            var mail = (string)Session["UyeMail"];
            var uye = db.TBLUyeler.FirstOrDefault(p => p.UyeMail == mail);
            uye.UyeSifre=u.UyeSifre;
            uye.UyeAd=u.UyeAd;
            uye.UyeSoyad=u.UyeSoyad;
            uye.UyeMail=u.UyeMail;
            uye.UyeTelefon=u.UyeTelefon;
            uye.UyeOkul=u.UyeOkul;
            uye.UyeKullaniciAdi=u.UyeKullaniciAdi;
            uye.UyeFotograf = u.UyeFotograf;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Kitaplarım()
        {
            var mail = (string)Session["UyeMail"];
            var uye = db.TBLUyeler.Where(x=>x.UyeMail==mail.ToString()).Select(y=>y.UyeID).FirstOrDefault();
            var kitaplar = db.TBLHareket.Where(b=>b.Uye==uye).ToList();
            return View(kitaplar);

        }
        public ActionResult Duyurular(TBLDuyurular d)
        {       
            var sorgu = db.TBLDuyurular.ToList();
            return View(sorgu);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login");
        }
        //Profilde kullandıgımız duyurular için
        public PartialViewResult Duyurular()
        {
            return PartialView();
        }
        public PartialViewResult Ayarlar()
        {
            var mail = (string)Session["UyeMail"];
            var id = db.TBLUyeler.Where(p => p.UyeMail == mail).Select(y => y.UyeID).FirstOrDefault(); ;
            var uyegetir = db.TBLUyeler.Find(id);
            return PartialView("Ayarlar",uyegetir);
        }
    }
}