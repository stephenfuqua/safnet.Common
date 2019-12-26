using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace safnet.TestHelper.AsyncDbSet
{
#pragma warning disable CA1063 // Implement IDisposable Correctly
    public class FakeAsyncEnumerator<TEntity> : IAsyncEnumerator<TEntity>
#pragma warning restore CA1063 // Implement IDisposable Correctly
    {
        private readonly IEnumerator<TEntity> _inner;

        public FakeAsyncEnumerator(IEnumerator<TEntity> inner)
        {
            _inner = inner;
        }

#pragma warning disable CA1063 // Implement IDisposable Correctly
        public void Dispose()
#pragma warning restore CA1063 // Implement IDisposable Correctly
        {
            _inner.Dispose();
        }

        public Task<bool> MoveNext(CancellationToken cancellationToken)
        {
            return Task.FromResult(_inner.MoveNext());
        }

        public TEntity Current => _inner.Current;
    }
}
