using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagazaUrunMvc.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace MagazaUrunMvc.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        DbMvcStokEntities db=new DbMvcStokEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var musteriListe = db.TblMusteris.ToList();

            var musteriListe = db.TblMusteris.Where(x=>x.durum==true).ToList().ToPagedList(sayfa, 3);// pagedlist ile sayfada kaç değer görünsün onu ayarlıyoruz ben 3 yaptım
            
            return View(musteriListe);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TblMusteri p)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            p.durum = true;
            db.TblMusteris.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSil(TblMusteri p)
        {
            var musteriBul = db.TblMusteris.Find(p.id);
            musteriBul.durum= false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            
            var mus = db.TblMusteris.Find(id);
            return View("MusteriGetir", mus);
        }
        public ActionResult MusteriGuncelle(TblMusteri t)
        {
            var mus=db.TblMusteris.Find(t.id);
            mus.ad=t.ad;
            mus.soyad=t.soyad;
            mus.sehir=t.sehir;
            mus.bakiye=t.bakiye;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}