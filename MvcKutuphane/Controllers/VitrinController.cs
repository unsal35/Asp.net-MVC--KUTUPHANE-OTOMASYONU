using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using PagedList;
using PagedList.Mvc;
using MvcKutuphane.Models.Siniflarim;
namespace MvcKutuphane.Controllers
{       
    [AllowAnonymous]

    public class VitrinController : Controller
    {
        DbMvcKutuphaneEntities1 db = new DbMvcKutuphaneEntities1();
        Class1 cs = new Class1();
        // GET: Vitrin
   
        [HttpGet]
        public ActionResult Index(int sayfa = 1)
        {
           // db.TBLYazar.ToList().ToPagedList(sayfa, 4);
            cs.KitapDeger = db.TBLKitap.ToList().ToPagedList(sayfa, 3);
            cs.HakkimizdaDeger = db.TBLHakkimizda.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(TBLiletisim i)
        {
            db.TBLiletisim.Add(i);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
