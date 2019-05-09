using Joole_MVC_Team1.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Joole_MVC_Team1.Controllers
{
    public class SearchController : Controller
    {
        Service service = new Service();
        // GET: Search
        public ActionResult SearchPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchPage(int id)
        {
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult ShowCategories()
        {
            return Json(service.ShowAllCategories(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AutoCompleteSubCategory(SubCategoryViewModel model)
        {
            return Json(service.AutoCompleteSubCategories(model.name, model.category_Id));
        }


    }
}