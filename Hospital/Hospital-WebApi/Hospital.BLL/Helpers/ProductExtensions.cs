using System;
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
    }
}