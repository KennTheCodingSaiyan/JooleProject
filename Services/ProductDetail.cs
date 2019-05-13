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
            return uow.product.GetByID(id);

        }


        /// test service 
        ///
     
      // public tblProduct getModelYearService(int id)
      //{
       //  return uow.product.();
      //}

    }
}