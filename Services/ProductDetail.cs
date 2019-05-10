using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using Repositories.Repositories;

namespace Services
{
    public partial class Service
    {

        public tblProduct getProductService(int id)
        {
            tblProduct product =  uow.product.GetByID(id);

            return product;

        }
    }
}