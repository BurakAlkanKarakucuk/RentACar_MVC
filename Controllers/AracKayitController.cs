using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using AracKiralama_MVC.Models.Entity;
using PagedList;

namespace AracKiralama_MVC.Controllers
{
    public class AracKayitController : Controller
    {
        AracKiralamaEntities3 db = new AracKiralamaEntities3();
        // GET: MusteriEkle
        public ActionResult Index()
        {
            var deger = db.Arac_Kayit.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult AracKayitEkle()
        {
            return View();
        }
        [HttpPost]
        //public ActionResult AracKayitEkle(Arac_Kayit deger)
        //{


        //    if (!ModelState.IsValid)
        //    {
        //        return View("AracKayitEkle");
        //    }
        //    db.Arac_Kayit.Add(deger);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        public ActionResult AracKayitEkle(Arac_Kayit deger)
        {
            if (ModelState.IsValid)
            {
                if (db.Arac_Kayit.Any(a => a.Plaka.Equals(deger.Plaka))) 
                {
                    Response.Write("<script>alert('Bu plaka'ya ait bir araç kayıtlı. Tekrar deneyiniz.')</script>");
                    return View("AracKayitEkle");
                }
                else
                {
                    db.Arac_Kayit.Add(deger);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Sil(int Id)
        {
            var deger = db.Arac_Kayit.Find(Id);
            db.Arac_Kayit.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AracKayitGetir(int Id)
        {
            var deger = db.Arac_Kayit.Find(Id);

            return View("AracKayitGetir", deger);
        }
        public ActionResult Guncelle(Arac_Kayit k)
        {
            var deger = db.Arac_Kayit.Find(k.Arac_ID);
            deger.Plaka = k.Plaka;
            deger.Marka = k.Marka;
            deger.Model = k.Model;
            deger.Yil = k.Yil;
            deger.Renk = k.Renk;
            deger.Yakit = k.Yakit;
            deger.Gunluk_Kira_Ucreti = k.Gunluk_Kira_Ucreti;
            deger.Sigorta_Bitis_Tarihi = k.Sigorta_Bitis_Tarihi;
            deger.Muayne_Bitis_Tarihi = k.Muayne_Bitis_Tarihi;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}