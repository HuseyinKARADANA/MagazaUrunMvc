using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagazaUrunMvc.Models.Entity;
namespace MagazaUrunMvc.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        DbMvcStokEntities db=new DbMvcStokEntities();
        public ActionResult Index(string p)
        {
           // var urunler = db.TblUrunlers.Where(x=>x.durum==true).ToList();
           var urunler=db.TblUrunlers.Where(x=>x.durum==true);
            if (!string.IsNullOrEmpty(p))
            {
                urunler=urunler.Where(x=>x.ad.Contains(p) && x.durum==true );
            }
            
            return View(urunler.ToList());
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> ktgr=(from x in db.TblKategoris.ToList()
                                       select new SelectListItem
                                       {
                                           Text=x.ad,
                                           Value=x.id.ToString()
                                       }).ToList();
            ViewBag.drop = ktgr;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(TblUrunler t)
        {
            var ktgr=db.TblKategoris.Where(x=>x.id==t.TblKategori.id).FirstOrDefault();
            t.TblKategori = ktgr;
            db.TblUrunlers.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id) 
        {
            List<SelectListItem> ktgr = (from x in db.TblKategoris.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.ad,
                                             Value = x.id.ToString()
                                         }).ToList();
            ViewBag.urunKategori = ktgr;
            var urun = db.TblUrunlers.Find(id);
            return View("UrunGetir", urun);
        }

        public ActionResult UrunGuncelle(TblUrunler p)
        {
            var urun=db.TblUrunlers.Find(p.id);
            urun.marka = p.marka;
            urun.satisFiyat = p.satisFiyat;
            urun.ad = p.ad;
            urun.stok = p.stok;
            urun.alisFiyat=p.alisFiyat;
            var ktg=db.TblKategoris.Where(x=>x.id==p.TblKategori.id).FirstOrDefault();
            urun.kategori = ktg.id;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(TblUrunler p)
        {
            var urunbul = db.TblUrunlers.Find(p.id);
            urunbul.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index"); 
        }
    }
}