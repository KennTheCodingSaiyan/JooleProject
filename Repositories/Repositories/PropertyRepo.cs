using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using System.Data.Entity;

namespace Repositories.Repositories
{
    public interface IPropertyRepo : IRepository<tblUser>
    {

    }
    public class PropertyRepo : Repository<tblUser>, IPropertyRepo
    {
        public PropertyRepo(DbContext context) : base(context)
        {

        }
    }
}