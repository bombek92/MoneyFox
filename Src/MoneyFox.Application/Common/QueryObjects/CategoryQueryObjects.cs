﻿using MoneyFox.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MoneyFox.Application.Common.QueryObjects
{
    /// <summary>
    ///     Provides Extensions for categories queries.
    /// </summary>
    public static class CategoryQueryObjects
    {
        /// <summary>
        ///     Adds a filter to a query to find all category with the passed name.
        /// </summary>
        /// <param name="query">Existing query.</param>
        /// <param name="name">Name to filter for</param>
        /// <returns>Query with the added filter.</returns>
        public static IQueryable<Category> NameEquals(this IQueryable<Category> query, string name)
        {
            return query.Where(x => x.Name.ToUpper().Equals(name.ToUpper()));
        }

        /// <summary>
        ///     Adds a filter for Categories who have a certain string in the name.
        /// </summary>
        /// <param name="query">Existing query.</param>
        /// <param name="searchterm">Search term to look for.</param>
        /// <returns>Query with the added filter.</returns>
        public static IEnumerable<Category> WhereNameContains(this List<Category> query, string searchterm)
        {
            return query.Where(category => category.Name.ToUpper().IndexOf(searchterm.ToUpper()) >= 0);
        }

        /// <summary>
        ///     Orders a category query by name.
        /// </summary>
        /// <param name="query">Existing query.</param>
        /// <returns>Ordered Query</returns>
        public static IQueryable<Category> OrderByName(this IQueryable<Category> query)
        {
            return query.OrderBy(category => category.Name);
        }
    }
}
