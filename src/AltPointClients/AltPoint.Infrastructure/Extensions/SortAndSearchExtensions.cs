using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Linq.Expressions;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AltPoint.Infrastructure.Extensions
{
    public static class SortAndSearchExtensions
    {
        public static IOrderedQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> items, string sortProperty, string sortDir) where TEntity : class
        {
            var method = sortDir.ToUpper() == "ASC" ? "OrderBy" : "OrderByDescending";
            var type = typeof(TEntity);
            var parameter = Expression.Parameter(type, "p");
            var property = type.GetProperty(sortProperty);
            var keySelector = Expression.Lambda(Expression.MakeMemberAccess(parameter, property), parameter );

            return (IOrderedQueryable<TEntity>)items.Provider.CreateQuery<TEntity>(
                Expression.Call(typeof(Queryable), method, new Type[] { type, property.PropertyType },
                                   items.Expression, Expression.Quote(keySelector)));
        }
        public static IQueryable<TEntity> Search<TEntity>(this IQueryable<TEntity> items, string searchItem) where TEntity : class
        {
            var parameter = Expression.Parameter(typeof(TEntity));
            Expression body = Expression.Constant(false);

            var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });

            var properties = typeof(TEntity).GetProperties().Where(property => property.PropertyType == typeof(string));
            foreach (var property in properties)
            {
                var nextExpression = Expression.Call(Expression.MakeMemberAccess(parameter, typeof(TEntity).GetProperty(property.Name)!), containsMethod!, Expression.Constant(searchItem));

                body = Expression.Or(body, nextExpression);
            }
            return items.Where(Expression.Lambda<Func<TEntity, bool>>(body, parameter));
        }
    }
}
