using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services
{
    public partial class Service
    {

        public List<SubCategory> AutoCompleteSubCategories(String input, int categoryId)
        {
            List<SubCategory> list = uow.subCategory.GetAll().Where(s => s.Category_ID.Equals(categoryId) && s.SubCategory_Name.ToLower().Contains(input.ToLower())).
                Select(s => new SubCategory(s.SubCategory_ID, s.Category_ID, s.SubCategory_Name)).ToList();
            return list;
        }

        public List<Category> ShowAllCategories()
        {
            List<Category> list = uow.category.GetAll().Select(cat => new Category(cat.Category_ID, cat.Category_Name)).ToList();
            return list;
        }
    }
}