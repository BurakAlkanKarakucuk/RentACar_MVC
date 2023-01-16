using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AracKiralama_MVC.Models.Entity;
using PagedList;

namespace AracKiralama_MVC.Controllers
{
    public class PersonelEkleController : Controller
    {
        AracKiralamaEntities3 db = new AracKiralamaEntities3();
        // GET: MusteriEkle
        public ActionResult Index()
        {
            var deger = db.Personel_Ekle.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult PersonelEkle_()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle_(Personel_Ekle deger)
        {

            if (!ModelState.IsValid)
            {
                return View("PersonelEkle_");
            }
            db.Personel_Ekle.Add(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int Id)
        {
            var deger = db.Personel_Ekle.Find(Id);
            db.Personel_Ekle.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir_(int Id)
        {
            var deger = db.Personel_Ekle.Find(Id);

            return View("PersonelGetir_", deger);
        }
        public ActionResult Guncelle(Personel_Ekle k)
        {
            var deger = db.Personel_Ekle.Find(k.Personel_ID);
            deger.TC = k.TC;
            deger.AdSoyad = k.AdSoyad;
            deger.Telefon = k.Telefon;
            deger.Adres = k.Adres;
            deger.Mail = k.Mail;
            deger.DogumTarihi = k.DogumTarihi;
            deger.DogumYeri = k.DogumYeri;
            deger.Yetki_Turu = k.Yetki_Turu;
            deger.Kullanıcı_ID = k.Kullanıcı_ID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}