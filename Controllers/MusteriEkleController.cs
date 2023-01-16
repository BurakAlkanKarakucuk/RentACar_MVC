using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AracKiralama_MVC.Models.Entity;
using PagedList;

namespace AracKiralama_MVC.Controllers
{
    public class MusteriEkleController : Controller
    {
        AracKiralamaEntities3 db = new AracKiralamaEntities3();
        // GET: MusteriEkle
        public ActionResult Index()
        {
            var deger = db.Musteri_Ekle.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult MusteriEkle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult MusteriEkle(Musteri_Ekle deger)
        {

            if (ModelState.IsValid)
            {
                if (db.Musteri_Ekle.Any(a => a.TC==deger.TC))
                {
                    ViewBag.Message = "Bu TC'ye ait bir müşteri kayıtlı. Tekrar deneyiniz.";
                    Response.Write("<script>alert('Bu TC'ye ait bir müşteri kayıtlı. Tekrar deneyiniz.')</script>");
                    return View("MusteriEkle");
                }
                else if (db.Musteri_Ekle.Any(a => a.Telefon==deger.Telefon))
                {
                    Response.Write("<script>alert('Bu telefona ait bir müşteri kayıtlı. Tekrar deneyiniz.')</script>");
                    return View("MusteriEkle");
                }
                else
                {
                    string a = deger.KrediKartNo.ToString();
                    string b = a.Substring(0, 4);
                    string c = a.Substring(4, 4);
                    string d = a.Substring(8, 4);
                    string e = a.Substring(12, 4);
                    a = b + "-" + c + "-" + d + "-" + e;
                    deger.KrediKartNo = a;
                    db.Musteri_Ekle.Add(deger);
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
            var deger = db.Musteri_Ekle.Find(Id);
            db.Musteri_Ekle.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult MusteriGetir(int Id)
        {
            var deger = db.Musteri_Ekle.Find(Id);

            return View("MusteriGetir", deger);
        }
        public ActionResult Guncelle(Musteri_Ekle k)
        {
            var deger = db.Musteri_Ekle.Find(k.Musteri_ID);
            deger.Telefon = k.Telefon;
            deger.Adres = k.Adres;
            deger.Mail = k.Mail;
            deger.KrediKartNo = k.KrediKartNo;
            deger.GecerlilikTarihi = k.GecerlilikTarihi;
            deger.CVV = k.CVV;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}