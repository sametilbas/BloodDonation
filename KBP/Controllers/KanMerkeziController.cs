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
    public class KanMerkeziController : Controller
    {
        OurDbContext db = new OurDbContext();
        // GET: KanMerkezi
        public ActionResult Index()
        {
            using (OurDbContext db = new OurDbContext())
            {
                return View(db.kanMerkeziAccounts.ToList());
            }
        }
        public ActionResult bagisciListele(KBP.Models.UyeAccount uye)
        {
            OurDbContext db = new OurDbContext();
            return View(db.uyeAccount.ToList());
        }

        public ActionResult Onayım(int? bid)
        {
            OurDbContext db = new OurDbContext();
            if (bid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UyeAccount uye = db.uyeAccount.Find(bid);
            if (uye == null)
            {
                return HttpNotFound();
            }
            return View(uye);

        }
        [HttpPost]
        public ActionResult Onayım([Bind(Include = "UserID,FirstName,LastName,UserName,Password,Email,Boy,Kilo,Yas,Adres,Tel,Aciklama,Kan_Grubu,ConfirmPassword")] UyeAccount uye, bool durum)
        {
            OurDbContext db = new OurDbContext();
            if (ModelState.IsValid)
            {
                if (durum == false)
                {
                    uye.UyeDurumu = true;
                    db.Entry(uye).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("bagisciListele");
                }
            }
            return View(uye);
        }

        public ActionResult Detay(int id)
        {
            OurDbContext db = new OurDbContext();
            return View(db.uyeAccount.Find(id));
        }
        public ActionResult Ekle(int? bid, int? kid)
        {
            OurDbContext db = new OurDbContext();
            ViewBag.UserID = bid;
            ViewBag.MerkezId = kid;
            return View();

        }
        [HttpPost]
        public ActionResult Ekle(KBP.Models.Kan ekle, int bid, int kid, KBP.Models.Stok stok)
        {
            OurDbContext db = new OurDbContext();

            ekle.UserID = bid;
            ekle.MerkezID = kid;
            db.kans.Add(ekle);

            stok.MerkezID = kid;
            stok.S_Adı = ekle.KanGrubu;
            stok.S_Miktari = ekle.Miktar;
            db.stoks.Add(stok);

            db.SaveChanges();
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(KBP.Models.KanMerkeziAccount account)
        {
            if (ModelState.IsValid)
            {
                using (OurDbContext db = new OurDbContext())
                {
                    db.kanMerkeziAccounts.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.CenterName + "kayıt işlemi başarılı";

            }
            return View();
        }

        public ActionResult Login()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Login(KBP.Models.KanMerkeziAccount user)
        {
            using (OurDbContext db = new OurDbContext())
            {
                var usr = db.kanMerkeziAccounts.Single(u => u.UserName == user.UserName && u.Password == user.Password);
                if (usr != null)
                {
                    Session["MerkezID"] = usr.MerkezID.ToString();
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

        public ActionResult LoggedIn(int? id)
        {
            if (Session["MerkezID"] != null)
            {
                string qwe = " SELECT StokID FROM Stok ORDER BY StokID ";
                int Apoz = 0, Aneg = 0, Bpoz = 0, Bneg = 0, ABpoz = 0, ABneg = 0, Spoz = 0, Sneg = 0;
                for (int i = 1; i < qwe.Length; i++)
                {
                    Stok stok = db.stoks.Find(i);
                    if (stok == null)
                    {
                        break;
                    }
                    if (stok.S_Adı == "A+")
                    {
                        int a = 0;
                        a = Int32.Parse(stok.S_Miktari);
                        Apoz += a;
                    }
                    if (stok.S_Adı == "A-")
                    {
                        int a = 0;
                        a = Int32.Parse(stok.S_Miktari);
                        Aneg += a;
                    }
                    if (stok.S_Adı == "AB+")
                    {
                        int a = 0;
                        a = Int32.Parse(stok.S_Miktari);
                        ABpoz += a;
                    }
                    if (stok.S_Adı == "AB-")
                    {
                        int a = 0;
                        a = Int32.Parse(stok.S_Miktari);
                        ABneg += a;
                    }
                    if (stok.S_Adı == "B+")
                    {
                        int a = 0;
                        a = Int32.Parse(stok.S_Miktari);
                        Bpoz += a;
                    }
                    if (stok.S_Adı == "B-")
                    {
                        int a = 0;
                        a = Int32.Parse(stok.S_Miktari);
                        Bneg += a;
                    }
                    if (stok.S_Adı == "0+")
                    {
                        int a = 0;
                        a = Int32.Parse(stok.S_Miktari);
                        Spoz += a;
                    }
                    if (stok.S_Adı == "0-")
                    {
                        int a = 0;
                        a = Int32.Parse(stok.S_Miktari);
                        Sneg += a;
                    }

                }
                ViewBag.apoz = Apoz;
                ViewBag.aneg = Aneg;
                ViewBag.bpoz = Bpoz;
                ViewBag.bneg = Bneg;
                ViewBag.abpoz = ABpoz;
                ViewBag.abneg = ABneg;
                ViewBag.spoz = Spoz;
                ViewBag.sneg = Sneg;

                KanMerkeziAccount uye = db.kanMerkeziAccounts.Find(id);
                return View(uye);

            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [HttpPost]
        public ActionResult LoggedIn([Bind(Include = "MerkezID,UserName,CenterName,Password,ConfirmPassword,Adres,Tel,Aciklama,Email")] KanMerkeziAccount uye)
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
        public ActionResult Edit(int? id)
        {
            OurDbContext db = new OurDbContext();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KanMerkeziAccount uye = db.kanMerkeziAccounts.Find(id);
            if (uye == null)
            {
                return HttpNotFound();

            }
            return View(uye);
        }
        [HttpPost]
        public ActionResult Edit([Bind(Include = "MerkezID,UserName,CenterName,Password,ConfirmPassword,Adres,Tel,Aciklama,Email")] KanMerkeziAccount uye)
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
    }
}