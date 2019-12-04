using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSTOCK.Models.Entity;

namespace MVCSTOCK.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLCATEGORIES.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult NewCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewCategory(TBLCATEGORIES p1)
        {
            if (!ModelState.IsValid)
            {
                return View("NewCategory");
            }
            db.TBLCATEGORIES.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult DELETE(int id)
        {
            var category = db.TBLCATEGORIES.Find(id);
            db.TBLCATEGORIES.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ImportCategory(int id)
        {
            var ctgr = db.TBLCATEGORIES.Find(id);
            return View("ImportCategory", ctgr);
        }
        public ActionResult UPDATE(TBLCATEGORIES p1)
        {
            var ctgr = db.TBLCATEGORIES.Find(p1.CATEGORYID);
            ctgr.CATEGORYNAME = p1.CATEGORYNAME;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}