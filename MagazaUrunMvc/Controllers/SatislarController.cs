using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagazaUrunMvc.Models.Entity;
namespace MagazaUrunMvc.Controllers
{
    public class SatislarController : Controller
    {
        // GET: Satislar
        DbMvcStokEntities db=new DbMvcStokEntities();
        public ActionResult Index()
        {
            var satislar=db.TblSatislars.ToList();
            return View(satislar);
        }
        [HttpGet] 

        public ActionResult YeniSatis()
        {
            //ürünler
            List<SelectListItem> urun = (from x in db.TblUrunlers.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.ad,
                                             Value = x.id.ToString()
                                         }).ToList();
            ViewBag.urunler = urun;
            //Müşteriler
            List<SelectListItem> musteri = (from x in db.TblMusteris.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.ad+" "+x.soyad,
                                             Value = x.id.ToString()
                                         }).ToList();
            ViewBag.musteriler = musteri;
            //personel
            List<SelectListItem> personel = (from x in db.TblPersonels.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.ad + " " + x.soyad,
                                                Value = x.id.ToString()
                                            }).ToList();
            ViewBag.personeller = personel;

            return View();
        }
        [HttpPost]  
        public ActionResult YeniSatis(TblSatislar p)
        {
            var urun = db.TblUrunlers.Where(x => x.id == p.TblUrunler.id).FirstOrDefault();
            var musteri = db.TblMusteris.Where(x => x.id == p.TblMusteri.id).FirstOrDefault();
            var personel = db.TblPersonels.Where(x => x.id == p.TblPersonel.id).FirstOrDefault();
            p.TblUrunler = urun;
            p.TblMusteri = musteri;
            p.TblPersonel = personel;
            p.tarih=DateTime.Parse(DateTime.Now.ToString());
            db.TblSatislars.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}