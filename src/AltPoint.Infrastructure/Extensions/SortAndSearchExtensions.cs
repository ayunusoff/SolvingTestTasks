using System.Linq.Expressions;
using System.Reflection;

namespace AltPoint.Infrastructure.Extensions
{
    public static class SortAndSearchExtensions
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
