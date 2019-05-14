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
            var tblSubCategories = uow.subCategory.GetAll();
            if(categoryId != 0)
            {
                return tblSubCategories.Where(s => s.Category_ID.Equals(categoryId) && s.SubCategory_Name.ToLower().Contains(input.ToLower())).
                    Select(s => new SubCategory(s.SubCategory_ID, s.Category_ID, s.SubCategory_Name)).ToList();
            } else
            {
                return tblSubCategories.Where(s => s.SubCategory_Name.ToLower().Contains(input.ToLower())).
                    Select(s => new SubCategory(s.SubCategory_ID, s.Category_ID, s.SubCategory_Name)).ToList();
            }
        }

        public List<Category> ShowAllCategories()
        {
            var list = uow.category.GetAll().Select(cat => new Category(cat.Category_ID, cat.Category_Name)).ToList();
            return list;
        }

        public List<SpecFilter> ShowSpecFiltersForSubCategory(int subCategoryId)
        {
            var filters = uow.specFilter.GetAll();
            var properties= uow.property.GetAll();
            var list = filters.Join(properties, f => f.Property_ID, p => p.Property_ID,
                (filter, property) => new SpecFilter(filter.Property_ID, filter.SubCategory_ID, property.Property_Name, filter.Min_Value, filter.Max_Value))
                .Where(f => f.subCategoryId.Equals(subCategoryId)).ToList();
            return list;
        }

        public List<TypeFilter> ShowTypeFiltersForSubCategory(int subCategoryId)
        {
            var list = uow.typeFilter.GetAll().Where(f => f.SubCategory_ID.Equals(subCategoryId))
                .Select(filter => new TypeFilter(filter.Property_ID, filter.SubCategory_ID, filter.Type_Name, "", filter.Type_Options.Split(',').ToList()))
                .ToList();
            return list;
        }

        public String getCategoryName(int categoryId)
        {
            return uow.category.GetByID(categoryId).Category_Name;
        }

        public String getSubCategoryName(int subCategoryId)
        {
            return uow.subCategory.GetByID(subCategoryId).SubCategory_Name;
        }

        public List<Product> getAllProductsByCriteria(SearchViewModel model)
        {
            var products = uow.product.GetAll().Where(p => p.SubCategory_ID.Equals(model.subCategoryId));
            var manufacturers = uow.manufacture.GetAll();
            var propertyValues = uow.propertyvalue.GetAll();
            var properties = uow.property.GetAll();
            var tFilters = ShowTypeFiltersForSubCategory(model.subCategoryId);
            var sFilters = ShowSpecFiltersForSubCategory(model.subCategoryId);

            if (model.yearMin != 0)
            {
                products = products.Where(p => (p.Model_Year.Year >= model.yearMin));
            }
            if(model.yearMax != 0)
            {
                products = products.Where(p => (p.Model_Year.Year <= model.yearMax));
            }
            if(model.typeFilters != null)
            {
                var typeFilters = from pv in propertyValues
                join filter in model.typeFilters
                on new { propertyId = pv.Property_ID, value = pv.Value } equals
                new { filter.propertyId, value = filter.value }
                select pv;

                products = from p in products
                join f in typeFilters
                on new { productId = p.Product_ID } equals
                new { productId = f.Product_ID }
                select p;
            }
            if(model.specFilters != null)
            {
                foreach(var f in model.specFilters)
                {
                    var ids = uow.propertyvalue.GetAll().Where(p => f.propertyId == p.Property_ID && (Double.Parse(p.Value) >= f.min)
                                            && (f.max >= Double.Parse(p.Value))).Select(p => p.Product_ID);
                    products = from p in products
                               join pi in ids
                               on new { productId = p.Product_ID } equals
                               new { productId = pi }
                               select p;
                }

            }
            return products.Select(p =>
                {
                    var manufacturerName = manufacturers.Where(m => m.Manufacturer_ID.Equals(p.Manufacturer_ID)).Select(m => m.Manufacturer_Name).First();
                    var props = propertyValues.Where(v => v.Product_ID.Equals(p.Product_ID)).ToList();
                    var list = tFilters.Join(props, f => f.propertyId, pv => pv.Property_ID,
                        (f, pv) => (f.typeName + ": " + pv.Value)).ToList();
                    var productValues = new List<string>();
                    productValues.AddRange(list);
                    list = sFilters.Join(props, f => f.propertyId, pv => pv.Property_ID,
                        (f, pv) => (f.propertyName + ": " + pv.Value)).ToList();
                    productValues.AddRange(list);
                    return new Product(p.Product_ID, manufacturerName, p.Product_Name, p.Product_Image, p.Series, p.Model, p.Model_Year.Year, productValues);
                }).ToList();
        }
    }
}