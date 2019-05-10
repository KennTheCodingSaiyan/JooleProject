using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using Services;

namespace Joole_MVC_Team1.Models
{
    public class ProductViewModel
    {

        public ProductViewModel(int id)
        {
            tblProduct product = new Service().getProductService(id);

        }

        public string Manufacture { get; set; }
        public string Series { get; set; }
        public string Model { get; set; }

        public string Commercial { get; set; }

        public string Application { get; set; }
        public string MountingLoaction { get; set; }
        public string Accessories { get; set; }

        public int ModelYear { get; set; }

    }
}