using AltPoint.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AltPoint.Infrastructure.Extensions
{
    public static class GetWithQueryExtensions
    {
        public static IEnumerable<TEntity> Sort<TEntity>(this IEnumerable<TEntity> items, List<string> sortProperty, List<string> sortDir) where TEntity : class
        {
            IOrderedEnumerable<TEntity>? temp = null;
            for (int i = 0; i < sortProperty.Count; ++i)
            {
                var type = typeof(TEntity);
                var parameter = Expression.Parameter(type, "p");
                var property = Expression.Property(parameter, sortProperty[i]);
                var lambda = Expression.Lambda<Func<TEntity, IComparable>>(Expression.Convert(property, typeof(IComparable)), parameter).Compile();
                if (temp is null) 
                {
                    temp = sortDir[i] == "Asc" ? items.OrderBy(lambda) : items.OrderByDescending(lambda);
                }
                else
                {
                    temp = sortDir[i] == "Asc" ? temp.ThenBy(lambda) : temp.ThenByDescending(lambda);
                }
            }
            return temp ?? items;
        }
        public static IQueryable<TEntity> Search<TEntity>(this IQueryable<TEntity> items, string searchItem) where TEntity : class // TODO
        {
            IQueryable<TEntity>? temp = null;
            Type type = typeof(TEntity);

            var propsValue = type.GetProperties()
                .Where(p => p.PropertyType == typeof(string))
                .Select(p => p.Name);

            var x = Expression.Parameter(type, "x");
            Expression call = Expression.Constant(false);
            var contains = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var query = Expression.Constant(searchItem);

            call = propsValue.Aggregate(call,
                (current, s) => Expression.OrElse(current,
                    Expression.Call(Expression.MakeMemberAccess(x, typeof(TEntity).GetProperty(s)!),
                        contains!, query)));
            var expr = Expression.Lambda<Func<TEntity, bool>>(call, x);

            temp = items.Where(expr);
            return temp ?? items;
        }
    }
}
