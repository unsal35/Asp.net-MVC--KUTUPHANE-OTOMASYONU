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
    public class AdminController : Controller
    {
        DbMvcKutuphaneEntities1 db = new DbMvcKutuphaneEntities1();
        // GET: Admin
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]  
        public ActionResult Login(Admin a)
        {
            var admin = db.Admin.FirstOrDefault(p=>p.Kulladi==a.Kulladi && p.Sifre==a.Sifre);
            if (admin!=null)
            {
                FormsAuthentication.SetAuthCookie(admin.Kulladi,admin.BeniHatirla );
                Session["Kulladi"]=admin.Kulladi.ToString();
                return RedirectToAction("Kartlar","istatistik");
            }
            else
            {
                return View();
            }     
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}