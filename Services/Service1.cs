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
            var list = uow.subCategory.GetAll().Where(s => s.Category_ID.Equals(categoryId) && s.SubCategory_Name.ToLower().Contains(input.ToLower())).
                Select(s => new SubCategory(s.SubCategory_ID, s.Category_ID, s.SubCategory_Name)).ToList();
            return list;
        }

        public List<Category> ShowAllCategories()
        {
            var list = uow.category.GetAll().Select(cat => new Category(cat.Category_ID, cat.Category_Name)).ToList();
            return list;
        }

        public List<SpecFilter> ShowSpecFiltersForSubCategory(int subCategoryId)
        {
            var filters = uow.filter.GetAll();
            var properties= uow.property.GetAll();
            var list = filters.Join(properties, f => f.Property_ID, p => p.Property_ID,
                (filter, property) => new SpecFilter(filter.Property_ID, filter.SubCategory_ID, property.Property_Name, filter.Min_Value, filter.Max_Value))
                .Where(f => f.subCategoryId.Equals(subCategoryId)).ToList();
            return list;
        }
    }
}