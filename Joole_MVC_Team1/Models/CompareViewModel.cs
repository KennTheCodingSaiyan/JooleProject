using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Services;
using Services.Models;
using DAL.Models;
using Repositories;
using System.Data.Entity;

namespace Joole_MVC_Team1.Models
{
    

    public class CompareViewModel
    {
        private DbContext product;

        public int id1 { get; set; }
        public int id2 { get; set; }
        public tblProduct p1 { get; set; }
        public tblProduct p2 { get; set; }

        public CompareViewModel(int id1, int id2)

        {
            Service S = new Service();
            //CompareViewModel Product1 = uow.product.GetByID(id1);
            //CompareViewModel Product2 = uow.product.GetByID(id2);
            //tblManufacturer productManufacturer1 = tblManufacturer.Manufacturer_Name;
            //tblManufacturer.Series;
            p1 = S.GetProductCompare(id1);
            p2 = S.GetProductCompare(id2);




        }
    }
}