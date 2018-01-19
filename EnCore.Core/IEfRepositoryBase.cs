using System.Collections.Generic;

namespace EnCore.Core
{
    public interface IEfRepositoryBase<TEntity>  : IEfRepositoryBase<int, TEntity>
        where TEntity : class
    {
    }
        public interface IEfRepositoryBase<TKey, TEntity> where TEntity : class
    {
        void Delete(TEntity entity);
        void Dispose();
        IEnumerable<TEntity> Get();
        IQueryResponse<TEntity> Get(QueryRequest queryRequest);
        TEntity GetById(TKey key);
        void Insert(TEntity entity);
        int SaveChanges();
        void Update(TEntity entity);
    }
}