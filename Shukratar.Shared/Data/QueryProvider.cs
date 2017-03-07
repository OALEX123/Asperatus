using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace Shukratar.Shared.Data
{
    public class QueryProvider : IQueryProvider
    {
        private readonly IQueryProvider _provider;

        public QueryProvider(IQueryProvider provider)
        {
            _provider = provider;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            return _provider.CreateQuery(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new Query<TElement>(_provider.CreateQuery<TElement>(expression));
        }

        public object Execute(Expression expression)
        {
            return _provider.Execute(expression);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return _provider.Execute<TResult>(expression);
        }
    }
}