using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSTOCK.Models.Entity;
namespace MVCSTOCK.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLCUSTOMERS.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult NewCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewCustomer(TBLCUSTOMERS p1)
        {
            if (!ModelState.IsValid)
            {
                return View("NewCustomer");
            }
            db.TBLCUSTOMERS.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult DELETE(int id)
        {
            var customer = db.TBLCUSTOMERS.Find(id);
            db.TBLCUSTOMERS.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ImportCustomer(int id)
        {
            var cst = db.TBLCUSTOMERS.Find(id);
            return View("ImportCustomer", cst);
        }
        public ActionResult UPDATE(TBLCUSTOMERS p1)
        {
            var cust = db.TBLCUSTOMERS.Find(p1.CUSTOMERID);
            cust.CUSTOMERNAME = p1.CUSTOMERNAME;
            cust.CUSTOMERLASTNAME = p1.CUSTOMERLASTNAME;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}