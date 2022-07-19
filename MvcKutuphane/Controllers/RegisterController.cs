using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {

        DbMvcKutuphaneEntities1 db = new DbMvcKutuphaneEntities1();
        // GET: Register
        [HttpGet]
        public ActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KayitOl(TBLUyeler u)
        {
            db.TBLUyeler.Add(u);
            db.SaveChanges();
            return View();
        }
    }
}