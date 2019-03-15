using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KBP.Models;

namespace KBP.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(KBP.Models.Duyuru duyuru)
        {
            OurDbContext db = new OurDbContext();
            Session.Clear();
            var sonuc = db.duyurus.OrderByDescending(x => x.DuyuruID);
            return View(sonuc.ToList());
        }

        public ActionResult tesvik()
        {
            return View();
        }

        public ActionResult Duyurucek()
        {
            OurDbContext db = new OurDbContext();
            return View(db.duyurus.ToList());
        }

    }
}