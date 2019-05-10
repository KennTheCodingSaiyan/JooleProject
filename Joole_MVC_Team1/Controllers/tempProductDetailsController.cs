using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repositories.Repositories;
using DAL.Models;
using Services;

namespace Joole_MVC_Team1.Controllers
{
    public class tempProductDetailsController : Controller
    {
        // GET: tempProductDetails
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Customer customer = db.Customers.Find(id);

            //if (customer == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(customer);
            id = 1;
            tblProduct product = new Service().getProductService((int)id);
            return View(product);
        }


    }
}