using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace safnet.TestHelper.AsyncDbSet
{
    public class FakeAsyncDbSet<TEntity> : DbSet<TEntity>, IQueryable, IAsyncEnumerable<TEntity>
        where TEntity : class
    {
        public IList<TEntity> List { get; } = new List<TEntity>();
        public IList<TEntity> Added { get; } = new List<TEntity>();
        public IList<TEntity> Updated { get; } = new List<TEntity>();
        public IList<TEntity> Deleted { get; } = new List<TEntity>();

        Type IQueryable.ElementType => typeof(TEntity);

        Expression IQueryable.Expression => List.AsQueryable().Expression;

        IQueryProvider IQueryable.Provider => new FakeAsyncQueryProvider<TEntity>(List.AsQueryable().Provider);

        IAsyncEnumerator<TEntity> IAsyncEnumerable<TEntity>.GetEnumerator()
        {
            return new FakeAsyncEnumerator<TEntity>(List.GetEnumerator());
        }
        
        public override EntityEntry<TEntity> Add(TEntity entity)
        {
            List.Add(entity);
            Added.Add(entity);

            // Returning null here is only safe because we never want to
            // do anything with an EntityEntry in this application.
            return null;
        }

        public override EntityEntry<TEntity> Update(TEntity entity)
        {
            List.Add(entity);
            Updated.Add(entity);

            // Returning null here is only safe because we never want to
            // do anything with an EntityEntry in this application.
            return null;
        }

        public override EntityEntry<TEntity> Remove(TEntity entity)
        {
            List.Add(entity);
            Deleted.Add(entity);

            // Returning null here is only safe because we never want to
            // do anything with an EntityEntry in this application.
            return null;
        }
    }
}
