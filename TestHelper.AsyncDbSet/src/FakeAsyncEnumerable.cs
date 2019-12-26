using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace safnet.TestHelper.AsyncDbSet
{
    public class FakeAsyncEnumerable<TEntity> : EnumerableQuery<TEntity>, IAsyncEnumerable<TEntity>, IQueryable<TEntity>
    {
        public FakeAsyncEnumerable(IEnumerable<TEntity> enumerable)
            : base(enumerable)
        {
        }

        public FakeAsyncEnumerable(Expression expression)
            : base(expression)
        {
        }

        public IAsyncEnumerator<TEntity> GetAsyncEnumerator()
        {
            return new FakeAsyncEnumerator<TEntity>(this.AsEnumerable().GetEnumerator());
        }
        public IAsyncEnumerator<TEntity> GetEnumerator()
        {
            return GetAsyncEnumerator();
        }

        IQueryProvider IQueryable.Provider => new FakeAsyncQueryProvider<TEntity>(this);
        
    }
}
