using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AracKiralama_MVC.Models.Entity;
using PagedList;

namespace AracKiralama_MVC.Controllers
{
    public class KullaniciController : Controller
    {
        AracKiralamaEntities3 db = new AracKiralamaEntities3();
        // GET: Kullanici
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpGet]
        public ActionResult kullaniciGiris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult kullaniciGiris (Kullanici deger,Kullanici deger1)
        {
            if (ModelState.IsValid)
            {
                if (db.Kullanici.Any(a => a.Kullanici_Ad.Equals(deger.Kullanici_Ad)) && db.Kullanici.Any(b => b.Sifre.Equals(deger1.Sifre)))
                {
                  
                    return RedirectToAction("Index", "MusteriEkle");
                }
                else
                {
                    Response.Write("<script>alert('Kullanıcı adı veya şifre yanlış. Tekrar deneyiniz.')</script>");
                    return View("kullaniciGiris");
                }
            }
            else
            {
                return RedirectToAction("kullaniciGiris");
            }
        }

    }

}