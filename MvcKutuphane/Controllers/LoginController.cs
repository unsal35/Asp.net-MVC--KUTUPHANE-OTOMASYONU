using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using System.Web.Security;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        DbMvcKutuphaneEntities1 db =new DbMvcKutuphaneEntities1(); 
        // GET: GirisYap
        [HttpGet]
   
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(TBLUyeler u)
        {
            var bilgiler = db.TBLUyeler.FirstOrDefault(p=>p.UyeMail==u.UyeMail && p.UyeSifre==u.UyeSifre);
          
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.UyeMail,bilgiler.Benihatirla);
                Session["UyeMail"] = bilgiler.UyeMail.ToString();
                //Session["UyeID"] = bilgiler.UyeID.ToString();
                //Session["UyeAd"] = bilgiler.UyeAd.ToString();
                //Session["UyeSoyad"] = bilgiler.UyeSoyad.ToString();
                //Session["UyeKullaniciAdi"]=bilgiler.UyeKullaniciAdi.ToString();
                //Session["UyeFotograf"] =bilgiler.UyeFotograf.ToString();
                //Session["UyeSifre"]=bilgiler.UyeSifre.ToString();
                //Session["UyeOkul"]=bilgiler.UyeOkul.ToString();                
                return RedirectToAction("Index","Panel");
            }
            else
            {
                return View();
            }
         
        }
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return View("Index","Vitrin");

        }
    }
}