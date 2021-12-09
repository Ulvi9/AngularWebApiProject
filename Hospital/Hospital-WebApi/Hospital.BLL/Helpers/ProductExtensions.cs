using System;
using System.Collections.Generic;
using System.Linq;
using Hospital.DAL.Entities;

namespace Hospital.BLL.Helpers
{
    public static class ProductExtensions
    {
        public static IQueryable<Product> Sort(this IQueryable<Product> query, string orderBy)
        {
            if (String.IsNullOrEmpty(orderBy)) return query.OrderBy(p => p.Name);
            query = orderBy switch
            {
                "price" => query.OrderBy(p => p.Price),
                "priceDesc" => query.OrderByDescending(p => p.Price),
                _ => query.OrderBy(p => p.Name)
            };
            return query;
        }
        public static IQueryable<Product>Search(this IQueryable<Product>query,string searchTerm)
        {
            if (String.IsNullOrEmpty(searchTerm)) return query;
            string lowerOrTrimSearchTerm = searchTerm.ToLower().Trim();
            return query.Where(p => p.Name.ToLower().Contains(lowerOrTrimSearchTerm));
        }

        public static IQueryable<Product> Filter(this IQueryable<Product> query, string brands, string types)
        {
            var brandList = new List<string>();
            var typeList = new List<string>();
            if (!String.IsNullOrEmpty(brands))
            {
                brandList.AddRange(brands.ToLower().Split(',').ToList());
            }
            if (!String.IsNullOrEmpty(types))
            {
                brandList.AddRange(types.ToLower().Split(',').ToList());
            }

            query = query.Where(p => brandList.Count == 0 || brandList.Contains(p.Name.ToLower()));//brand
            query = query.Where(p => typeList.Count == 0 || typeList.Contains(p.Name.ToLower()));//type
            return query;
        }
    }
}