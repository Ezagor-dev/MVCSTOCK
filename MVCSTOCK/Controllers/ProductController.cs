using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSTOCK.Models.Entity;
namespace MVCSTOCK.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLPRODUCTS.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SelectListItem> degerler = (from i in db.TBLCATEGORIES.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.CATEGORYNAME,
                                                 Value = i.CATEGORYID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(TBLPRODUCTS p1)
        {
            var ctgr = db.TBLCATEGORIES.Where(m => m.CATEGORYID == p1.TBLCATEGORIES.CATEGORYID).FirstOrDefault();
            p1.TBLCATEGORIES = ctgr;
            db.TBLPRODUCTS.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DELETE(int id)
        {
            var product = db.TBLPRODUCTS.Find(id);
            db.TBLPRODUCTS.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ImportProduct(int id)
        {
            var prodc = db.TBLPRODUCTS.Find(id);

            List<SelectListItem> degerler = (from i in db.TBLCATEGORIES.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.CATEGORYNAME,
                                                 Value = i.CATEGORYID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("ImportProduct", prodc);
        }
        public ActionResult UPDATE(TBLPRODUCTS p)
        {
            var product = db.TBLPRODUCTS.Find(p.PRODUCTID);
            product.PRODUCTNAME = p.PRODUCTNAME;
            product.BRAND = p.BRAND;
            product.STOCK = p.STOCK;
            product.PRICE = p.PRICE;
            //product.PRODUCTCATEGORY = p.PRODUCTCATEGORY;
            var ctgr = db.TBLCATEGORIES.Where(m => m.CATEGORYID == p.TBLCATEGORIES.CATEGORYID).FirstOrDefault();
            product.PRODUCTCATEGORY = ctgr.CATEGORYID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}