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
    public class iletisimController : Controller
    {
        DbMvcKutuphaneEntities1 db=new DbMvcKutuphaneEntities1();   
        // GET: iletisim
        public ActionResult Index(int sayfa=1)
        {
            var sorgu = db.TBLiletisim.ToList().ToPagedList(sayfa,4);
            return View(sorgu);
        }
    }
}