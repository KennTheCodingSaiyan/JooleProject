using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using System.Data.Entity;

namespace Repositories.Repositories
{
    public interface ISubcategoryRepo : IRepository<tblSubCategory>
    {

    }

    public class SubcategoryRepo : Repository<tblSubCategory>, ISubcategoryRepo
    {
        public SubcategoryRepo(DbContext context) : base(context)
        {

        }
    }
}