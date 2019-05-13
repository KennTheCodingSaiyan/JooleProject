using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL.Models;
using Services;
using Joole_MVC_Team1.Models;



namespace Joole_MVC_Team1.Controllers
{
    public class CompareController : Controller
    {
        Service service = new Service();
        private joole_team1Entities db = new joole_team1Entities();

        // GET: Compare
        public ActionResult Compare(int id1, int id2)
        {


          
                return View(new CompareViewModel(id1, id2));
            
            //      var tblProducts = db.tblProducts.Include(t => t.tblDocument).Include(t => t.tblManufacturer).Include(t => t.tblSale).Include(t => t.tblSubCategory);

            //       return View(tblProducts.ToList());
        }

  
    }
}
