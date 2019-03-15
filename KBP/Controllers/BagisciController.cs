using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KBP.Models;

namespace KBP.Controllers
{
   
        public class BagisciController : Controller
        {

            OurDbContext db = new OurDbContext();
            public ActionResult Index()
            {
                return View();
            }

            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                UyeAccount uye = db.uyeAccount.Find(id);
                if (uye == null)
                {
                    return HttpNotFound();
                }
                return View(uye);
            }
            [HttpPost]
            public ActionResult Edit([Bind(Include = "UserID,FirstName,LastName,UserName,Password,Email,Boy,Kilo,Yas,Adres,Tel,Aciklama,Kan_Grubu,ConfirmPassword")] UyeAccount uye)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(uye).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(uye);
            }
            public ActionResult Register()
            {
                return View();
            }
            [HttpPost]
            public ActionResult Register(KBP.Models.UyeAccount account)
            {
                if (ModelState.IsValid)
                {
                    using (OurDbContext db = new OurDbContext())
                    {
                        db.uyeAccount.Add(account);
                        db.SaveChanges();
                    }
                    ModelState.Clear();
                    ViewBag.Message = account.FirstName + "" + account.LastName + "kayıt işlemi başarılı";
                }
                return View();
            }

            public ActionResult Login()
            {
                return View();
            }
            [HttpPost]
            public ActionResult Login(KBP.Models.UyeAccount user)
            {
                using (OurDbContext db = new OurDbContext())
                {
                    var usr = db.uyeAccount.Single(u => u.UserName == user.UserName && u.Password == user.Password);
                    if (usr != null)
                    {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["UserName"] = usr.UserName.ToString();
                    Session["UyeDurumu"] = usr.UyeDurumu.ToString();
                    Session["Yas"] = usr.Yas;
                    Session["Kilo"] = usr.Kilo;
                    return RedirectToAction("LoggedIn");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");
                    }
                }
                return View();
            }
            public ActionResult LoggedIn()
            {
                if (Session["UserID"] != null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Register");
                }
            }
            //public ActionResult bilgiler()
            //{
            //    return View("Update");
            //}
            public ActionResult SignOut()
            {
                Session.Clear();
                return RedirectToAction("Index", "Home");

            }
            public ActionResult gecmis(int id, bool? durum)
            {
                if (durum == true)
                {
                    var qwe = db.kans.Where(x => x.UserID == id).ToList();
                    return View(qwe);
                }
                return View(db.kans.ToList());

            }
            public ActionResult Tesvik()
            {
                return View();
            }
        }
    
}