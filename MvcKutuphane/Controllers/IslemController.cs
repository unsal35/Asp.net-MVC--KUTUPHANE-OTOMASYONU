using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
   
    public class IslemController : Controller
    {
        DbMvcKutuphaneEntities1 db = new DbMvcKutuphaneEntities1();
        // GET: Islem
        public ActionResult Index()
        {
            var sorgu = db.TBLHareket.Where(p=>p.IslemDurum==true).ToList();
            return View(sorgu);
        }
    }
}