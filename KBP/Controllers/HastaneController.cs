using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using KBP.Models;
using UserIdentity.Models;

namespace KBP.Controllers
{
    public class HastaneController : Controller
    {
        OurDbContext db = new OurDbContext();
        // GET: Hastane
        public ActionResult Index()
        {
            using (OurDbContext db = new OurDbContext())
            {
                return View(db.hastaneAccounts.ToList());
            }
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(KBP.Models.HastaneAccount account)
        {
            if (ModelState.IsValid)
            {
                using (OurDbContext db = new OurDbContext())
                {
                    db.hastaneAccounts.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.HospitalName + "kayıt işlemi başarılı";

            }
            return View();
        }

        public ActionResult Login()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Login(KBP.Models.HastaneAccount user)
        {
            using (OurDbContext db = new OurDbContext())
            {
                var usr = db.hastaneAccounts.Single(u => u.UserName == user.UserName && u.Password == user.Password);
                if (usr != null)
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["UserName"] = usr.UserName.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");
                }
            }
            return View();
        }

        public ActionResult Edit(int? id)
        {
            OurDbContext db = new OurDbContext();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HastaneAccount uye = db.hastaneAccounts.Find(id);
            if (uye == null)
            {
                return HttpNotFound();
            }
            return View(uye);
        }
        [HttpPost]
        public ActionResult Edit([Bind(Include = "UserID,HospitalName,UserName,Email,Password,ConfirmPassword,Adres,Tel,Aciklama")] HastaneAccount uye)
        {
            OurDbContext db = new OurDbContext();
            if (ModelState.IsValid)
            {
                db.Entry(uye).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("LoggedIn");
            }
            return View(uye);
        }
        public ActionResult LoggedIn(int? id)
        {
            if (Session["UserID"] != null)
            {
                HastaneAccount uye = db.hastaneAccounts.Find(id);
                return View(uye);
            }
            else
            {
                return RedirectToAction("Login");
            }

        }
        [HttpPost]
        public ActionResult LoggedIn([Bind(Include = "UserID,UserName,HospitalName,Password,ConfirmPassword,Adres,Tel,Aciklama,Email")] HastaneAccount uye)
        {
            OurDbContext db = new OurDbContext();

            if (ModelState.IsValid)
            {
                db.Entry(uye).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Loggedin");
            }
            return View(uye);
        }



        public ActionResult DuyuruEkle(int id)
        {
            ViewBag.UserID = id;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
         public ActionResult DuyuruEkle(KBP.Models.Duyuru ekle,KBP.Models.UyeAccount uye)
        {
            OurDbContext db = new OurDbContext();
            db.duyurus.Add(ekle);
            db.SaveChanges();

            string qwe = " SELECT UserID FROM UyeAccount ORDER BY UserID DESC LIMIT 1";

                var body = new StringBuilder();
                body.AppendLine("Ad & Soyad: " );
                body.AppendLine("E-Mail Adresi: ");
                body.AppendLine("Konu: " + ekle.D_Ad);
                Mail.MailSender(body.ToString());     
            return View();
        }

        }
    }
