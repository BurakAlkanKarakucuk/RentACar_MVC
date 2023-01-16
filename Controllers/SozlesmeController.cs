using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using AracKiralama_MVC.Models.Entity;
using PagedList;

namespace AracKiralama_MVC.Controllers
{
    public class SozlesmeController : Controller
    {
        AracKiralamaEntities3 db = new AracKiralamaEntities3();
        // GET: Sozlesme
        public ActionResult Index()
        {
            var deger = db.Sozlesme_Ekle.ToList();
            return View(deger);
        }
        public JsonResult UcretGetir(int p)
        {
            var ucreT = (from x in db.Arac_Kayit
                         
                           where x.Arac_ID == p
                           select new
                           {
                               Text = x.Gunluk_Kira_Ucreti.ToString(),
                               Value = x.Arac_ID.ToString(),
                           }).ToList();


            return Json(ucreT, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult SozlesmeEkle()
        {
            List<SelectListItem> deger1 = (from i in db.Arac_Kayit.ToList() //ilişkili tablolarda geçerli
                                           select new SelectListItem
                                           {
                                               Text = i.Plaka.ToString(),
                                               Value = i.Arac_ID.ToString()

                                           }).ToList();

            List<SelectListItem> deger2 = (from i in db.Musteri_Ekle.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.TC.ToString(),
                                               Value = i.Musteri_ID.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from i in db.Arac_Kayit.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Gunluk_Kira_Ucreti.ToString(),
                                               Value = i.Gunluk_Kira_Ucreti.ToString()
                                           }).ToList();
            List<SelectListItem> deger4 = (from i in db.Personel_Ekle.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AdSoyad.ToString(),
                                               Value = i.Personel_ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;

            return View();
        }
        [HttpPost]
        public ActionResult SozlesmeEkle(Sozlesme_Ekle deger)
        {

            decimal ucrett = (from p in db.Arac_Kayit
                        where p.Arac_ID == deger.Arac_ID
                        select p.Gunluk_Kira_Ucreti).SingleOrDefault();
       
            DateTime tarih1 =  (deger.Alis_Tarihi);
            DateTime tarih2 =  (deger.VerisTarihi);
            TimeSpan fark = tarih2 - tarih1;
            decimal farki=Convert.ToDecimal(fark.TotalDays.ToString());
            deger.Odenecek_Fiyat = ucrett  * (farki);
            db.Sozlesme_Ekle.Add(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int Id) 
        {
            var deger = db.Sozlesme_Ekle.Find(Id);
            db.Sozlesme_Ekle.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SozlesmeGetir(int Id)
        {
            var deger = db.Sozlesme_Ekle.Find(Id);

            return View("SozlesmeGetir", deger);
        }
        public ActionResult Guncelle(Sozlesme_Ekle k)
        {
            var deger = db.Sozlesme_Ekle.Find(k.Sozlesme_ID);
            deger.Musteri_Ekle.TC = k.Musteri_Ekle.TC;
            deger.Arac_Kayit.Plaka = k.Arac_Kayit.Plaka;
            deger.Odenecek_Fiyat = k.Odenecek_Fiyat;
            deger.Alis_Tarihi = k.Alis_Tarihi;
            deger.VerisTarihi = k.VerisTarihi;
            deger.Personel_ID = k.Personel_ID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}