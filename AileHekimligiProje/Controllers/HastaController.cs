using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.EntityModel.SchemaObjectModel;
using System.Data.EntityClient;
using AileHekimligiProje.Models.EntityFramework;
using AileHekimligiProje.Controllers;
using System.Data.Entity.Validation;
using System.Web.Security;


namespace AileHekimligiProje.Controllers
{


    public class HastaController : Controller 
    {
        //
        // GET: /Hasta/



        Model1 db = new Model1();

        public ActionResult Index()
        {
            return View();
        }
      
        public ActionResult Giris()
        {
            return View();
        }


       
        [HttpPost]
        public ActionResult Giris(Hasta model)
        {
            try
            {
                var varmi = db.Hastas.Where(i => i.TC == model.TC).SingleOrDefault();
                if (varmi == null)
                {
                    return View();
                }
                if (varmi.Sifre == model.Sifre)
                {
                    Session["username"] = varmi.AdSoyad;
                    Session["Id"] = varmi.Id;
                    
                    return RedirectToAction("homepage", "Hasta");
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

      

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(Hasta hasta)
        {
            db.Hastas.Add(hasta);
            db.SaveChanges();
            return RedirectToAction("Giris", "Hasta");
        }

  

        [ChildActionOnly]
        public PartialViewResult _alternativelist(string q)
        {
            var randevu = db.Doktors.Where(i => i.SehirAdi.Contains(q)|| i.IlceAdi.Contains(q)||i.AdSoyad.Contains(q) || i.HastaneAdi.Contains(q )).ToList();

            
            
            return PartialView(randevu);
        }
     
        public ActionResult homepage( )
        {
            //List<SelectListItem> degerler1 = (from i in db.Hastanes.ToList() select new SelectListItem { Text = i.SehirAdi, Value = i.HastaneId.ToString() }).ToList();
            //ViewBag.dgr = degerler1;
            //List<SelectListItem> degerler2 = (from i in db.Hastanes.ToList() select new SelectListItem { Text = i.IlceAdi, Value = i.HastaneId.ToString() }).ToList();
            //ViewBag.dgr2 = degerler2;
            //List<SelectListItem> degerler3 = (from i in db.Hastanes.ToList() select new SelectListItem { Text = i.HastaneAdi, Value = i.HastaneId.ToString() }).ToList();
            //ViewBag.dgr3 = degerler3;
            //List<SelectListItem> degerler4 = (from i in db.Doktors.ToList() select new SelectListItem { Text = i.AdSoyad.ToString(), Value = i.HastaneId.ToString() }).ToList();
            //ViewBag.dgr4 = degerler4;
            //List<SelectListItem> degerler5 = (from i in db.Randevulars.ToList() select new SelectListItem { Text = i.RandevuSaati.ToString(), Value = i.DoktorId.ToString() }).ToList();
            //ViewBag.dgr5 = degerler5;

            
            return View();

        }
        [HttpPost]
        public ActionResult homegape(int id, Randevular Randevu)
        {

            var model = db.Randevulars.Find(id);
            var randevual = db.Randevulars.Find(Randevu.Id);
            if (randevual == null)
            {
                return HttpNotFound();
            }
            randevual.DoktorId = Randevu.DoktorId;
            randevual.RandevuDurum = 1;
            randevual.RandevuSaati = Randevu.RandevuSaati;
            var randevuhasta = db.Hastas.Find(Randevu.Id);
            randevuhasta.RandevuId = Randevu.Id;
            db.SaveChanges();

            
            return RedirectToAction("homepage", "Hasta");
        }


        public ActionResult randevuislem(int id)
        {

            //var model = db.Doktors.Find(id);
            //List<SelectListItem> degerler1 = (from a in db.Randevulars
            //                                  where a.Id == model.Id
            //                                  select new SelectListItem { Text = a.RandevuSaati.ToString(), Value = a.DoktorId.ToString() }).ToList();
            //ViewBag.dgr = degerler1;
            var model = db.Randevulars.Where(i => i.DoktorId == id && i.RandevuDurum==0).ToList();
            if (model == null)
                return HttpNotFound();
            return View("randevuislem", model);


        }


        public ActionResult randevual(int id)
        {
            var model = db.Randevulars.Find(id);
            if (model == null)
                return HttpNotFound();
            return View("randevual", model);
        }
        [HttpPost]
        public ActionResult randevual(Randevular Randevu)
        {
            
            var randevual = db.Randevulars.Find(Randevu.Id);
            if (randevual == null)
            {
                return HttpNotFound();
            }
            
            randevual.RandevuDurum = 1;
            randevual.RandevuSaati = Randevu.RandevuSaati;
            randevual.DoktorAdi = Randevu.DoktorAdi;
            randevual.HastaAdi = Randevu.HastaAdi;
            randevual.HastaId = Randevu.HastaId;
            
            db.SaveChanges();
            return RedirectToAction("islembasarili","Hasta");
        }
        public ActionResult islembasarili()
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
