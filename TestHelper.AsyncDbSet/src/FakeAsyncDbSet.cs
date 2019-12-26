using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace safnet.TestHelper.AsyncDbSet
{
    public class FakeAsyncDbSet<TEntity> : DbSet<TEntity>, IQueryable, IAsyncEnumerable<TEntity>
        where TEntity : class
    {
        public List<TEntity> List { get; } = new List<TEntity>();
        
        Type IQueryable.ElementType => typeof(TEntity);

        Expression IQueryable.Expression => List.AsQueryable().Expression;

        IQueryProvider IQueryable.Provider => new FakeAsyncQueryProvider<TEntity>(List.AsQueryable().Provider);

        IAsyncEnumerator<TEntity> IAsyncEnumerable<TEntity>.GetEnumerator()
        {
            return new FakeAsyncEnumerator<TEntity>(List.GetEnumerator());
        }
        
        public override void AddRange(params TEntity[] entities)
        {
            List.AddRange(entities);
        }
    }
}
