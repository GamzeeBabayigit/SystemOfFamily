using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AileHekimligiProje.Models.EntityFramework;
using AileHekimligiProje.Controllers;
using Newtonsoft.Json;
using FireSharp.Interfaces;
using FireSharp.Config;
using FireSharp.Response;
using Newtonsoft.Json.Linq;
using System.Web.Security;

namespace AileHekimligiProje.Controllers
{
    public class DoktorController : Controller
    {
        //
        // GET: /Doktor/

        Model1 db = new Model1();

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "gba9vdtAeeJyTrq3Oly8M1VfiSZScXamTSrb1Yhs",
            BasePath = "https://ailehekimligisistemi-4e122.firebaseio.com/"
        };
        IFirebaseClient client;

        public ActionResult Index()
        {
            return View();
            
        }

        public ActionResult graphdetail()
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("/raspberry/");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var list = new List<Veriler>();
            foreach (var item in data)
            {
                list.Add(JsonConvert.DeserializeObject<Veriler>(((JProperty)item).Value.ToString()));
            }
           
            return View(list);
        }

       
        public ActionResult fordatetime()
        {
            return View("fordatetime");
        }
        [HttpPost]
        public ActionResult fordatetime(Randevular randevu)
        {
            db.Randevulars.Add(randevu);
            db.SaveChanges();
            return RedirectToAction("Settings","Doktor");
        }

        [ChildActionOnly]
        public PartialViewResult _fordetail()
        {
       
            var veri = db.Verilers.ToList();
            return PartialView("_fordetail", veri);
        }

        public ActionResult _forgraph()
        {
            return View();
        }
        public ActionResult Settings()
        {
            var randevus = from a in db.Randevulars                
                            select a;                   
            
            return View(randevus);
        }
        [HttpPost]
        public ActionResult Settings(Randevular randevu)
        {
            db.Randevulars.Add(randevu);
            db.SaveChanges();
            return View();
        }
        public ActionResult dailydate(Randevular model)
        {
            var rande = db.Randevulars.ToList();
            return View(rande);
        }
        public ActionResult Listele(Doktor model)
        {
            var patient = db.Hastas.ToList();
            return View(patient);
        }

        //GET: AileHekimligiProje/Creat
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(Hasta hasta)
        {
            db.Hastas.Add(hasta);
            db.SaveChanges();
            return RedirectToAction("Listele","Doktor");
        }

        public ActionResult Guncelle(int id)
        {
                var model = db.Hastas.Find(id);
            if (model == null)
                return HttpNotFound();
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult Guncelle(Hasta hasta)
        {
                var updatehasta = db.Hastas.Find(hasta.Id);
                if(updatehasta==null)
                {
                    return HttpNotFound();
                }
                
                updatehasta.AdSoyad = hasta.AdSoyad;
                updatehasta.Alkol = hasta.Alkol;
                updatehasta.AnneAdi = hasta.AnneAdi;
                updatehasta.BabaAdi = hasta.BabaAdi;
                updatehasta.CalismaDurumu = hasta.CalismaDurumu;
                updatehasta.Cinsiyet = hasta.Cinsiyet;
                updatehasta.IsYeriBilgileri = hasta.IsYeriBilgileri;
                updatehasta.KullanilanIlaclar = hasta.KullanilanIlaclar;
                updatehasta.SeriNo = hasta.SeriNo;
                updatehasta.Sigara = hasta.Sigara;
                updatehasta.TC = hasta.TC;
                updatehasta.Yas = hasta.Yas;
                updatehasta.YenmiIlac = hasta.YenmiIlac;
                updatehasta.Teshis = hasta.Teshis;
                db.SaveChanges();
            return RedirectToAction("Listele", "Doktor"); 
            }

            public ActionResult Sil(int id)
                {
                  var deletehasta = db.Hastas.Find(id);
                  if (deletehasta == null)
                     return HttpNotFound();
                 db.Hastas.Remove(deletehasta);
                 db.SaveChanges();
                 return RedirectToAction("Listele");
                }
            public ActionResult SilR(int id)
            {
                var deletehasta = db.Randevulars.Find(id);
                if (deletehasta == null)
                    return HttpNotFound();
                db.Randevulars.Remove(deletehasta);
                db.SaveChanges();
                return RedirectToAction("dailydate");
            }

            public ActionResult Temizle(int id)
            {
                var deleterandevu = db.Randevulars.Find(id);
                if (deleterandevu == null)
                    return HttpNotFound();
                db.Randevulars.Remove(deleterandevu);
                db.SaveChanges();
                return RedirectToAction("Settings");
            }
          
          public ActionResult Detail(int id)
            {
                var model = db.Hastas.Find(id);
                if (model == null)
                    return HttpNotFound();
                return View("Detail", model);
            }
        [HttpPost]
          public ActionResult Detail(Hasta hasta)
          {
              var updatehasta = db.Hastas.Find(hasta.Id);
              if (updatehasta == null)
              {
                  return HttpNotFound();
              }

              updatehasta.AdSoyad = hasta.AdSoyad;
              updatehasta.Alkol = hasta.Alkol;
              updatehasta.AnneAdi = hasta.AnneAdi;
              updatehasta.BabaAdi = hasta.BabaAdi;
              updatehasta.CalismaDurumu = hasta.CalismaDurumu;
              updatehasta.Cinsiyet = hasta.Cinsiyet;
              updatehasta.IsYeriBilgileri = hasta.IsYeriBilgileri;
              updatehasta.KullanilanIlaclar = hasta.KullanilanIlaclar;
              updatehasta.SeriNo = hasta.SeriNo;
              updatehasta.Sigara = hasta.Sigara;
              updatehasta.TC = hasta.TC;
              updatehasta.Yas = hasta.Yas;
              updatehasta.YenmiIlac = hasta.YenmiIlac;
              updatehasta.Teshis = hasta.Teshis;

              db.SaveChanges();

              return RedirectToAction("Detail",hasta);
          }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Doktor model)
        {
            try
            {
                var varmi = db.Doktors.Where(i => i.AdSoyad == model.AdSoyad).SingleOrDefault();
                if (varmi == null)
                {
                    return View();
                }
                if (varmi.Sifre == model.Sifre)
                {
                    Session["username"] = varmi.AdSoyad;
                    Session["Id"] = varmi.Id;
                    return RedirectToAction("Listele", "Doktor");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

            public ActionResult Newdoc()
             {
                 return View("Newdoc");
             }
        [HttpPost]
            public ActionResult Newdoc(Doktor doktor)
             {
                 db.Doktors.Add(doktor);
                 db.SaveChanges();
                return RedirectToAction("Login","Doktor");
             }

        public ActionResult Profil()
            {
                return View();  
            }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        } 
        }
    }
