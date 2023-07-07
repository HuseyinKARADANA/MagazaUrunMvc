using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagazaUrunMvc.Models.Entity;
namespace MagazaUrunMvc.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        DbMvcStokEntities db=new DbMvcStokEntities();

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet] 
        public ActionResult YeniAdmin() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniAdmin(TblAdmin p)
        {
            db.TblAdmins.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}