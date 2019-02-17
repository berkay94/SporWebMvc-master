using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SporWebMvc.Models;

namespace SporWebMvc.Controllers
{
    public class KullaniciHesapController : Controller
    {

        AppDbContext db = new AppDbContext();
        public ActionResult KayitOl()
        {
            var sporlar = db.Sporlar.ToList();
            return View(Tuple.Create<Kullanici,List<Sporlar>>(new Kullanici(),sporlar));
           
        }

        [HttpPost]
        public ActionResult KayitOl([Bind(Prefix ="Item1")]Kullanici Model1, [Bind(Prefix = "Item2")]Sporlar Model2,Kullanici k)
        {
            if(ModelState.IsValid)
            {
                using (AppDbContext db = new AppDbContext())
                {
                    db.Kullanicilar.Add(k);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = k.Ad + " " + k.Soyad + " " + "kaydınız oluştu";
            }
            return View();
        }

        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(Kullanici k)
        {
            using (AppDbContext db = new AppDbContext())
            {
                try
                {
                    var kullanici = db.Kullanicilar.Single(u => u.Email == k.Email && u.Sifre == k.Sifre);
                    if(kullanici!=null)
                    {
                        Session["Id"] = kullanici.Id.ToString();
                        Session["Email"] = kullanici.Email.ToString();
                        return RedirectToAction("AnaSayfa");
                    }

                }
                catch (Exception)
                {

                    ModelState.AddModelError("", "Email veya sifre hatali");
                }
            }
            return View();
        }

        public ActionResult AnaSayfa()
        {
            if(Session["Id"]!=null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("GirisYap");
            }
        }

    }
}