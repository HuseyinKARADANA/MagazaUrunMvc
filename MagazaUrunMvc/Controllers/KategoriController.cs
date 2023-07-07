using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagazaUrunMvc.Models.Entity;
namespace MagazaUrunMvc.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DbMvcStokEntities db=new DbMvcStokEntities();
        public ActionResult Index()
        {
            var kategoriler=db.TblKategoris.ToList();
            return View(kategoriler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(TblKategori kategori)
        {
            db.TblKategoris.Add(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var ktg = db.TblKategoris.Find(id);
            db.TblKategoris.Remove(ktg);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TblKategoris.Find(id);
            return View("KategoriGetir",ktgr);
        }
        public ActionResult KategoriGuncelle(TblKategori k)
        {
            var ktgr=db.TblKategoris.Find(k.id);
            ktgr.ad = k.ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}