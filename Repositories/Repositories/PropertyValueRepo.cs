using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using System.Data.Entity;

namespace Repositories.Repositories
{
    public interface IPropertyValueRepo : IRepository<tblUser>
    {

    }

    public class PropertyValueRepo : Repository<tblUser>, IPropertyValueRepo
    {
        public PropertyValueRepo(DbContext context) : base(context)
        {

        }
    }
}