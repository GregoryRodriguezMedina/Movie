using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnCore.Core
{
    public partial class EfRepositoryBase<TEntity> : EfRepositoryBase<int, TEntity>
    where TEntity : class
    {
        public EfRepositoryBase(DbContext context) : base(context)
        {
        }
    }
    public partial class EfRepositoryBase<TKey, TEntity> 
        : IEfRepositoryBase<TKey, TEntity> //: IEfRepositoryAsync<TKey, TEntity>
    where TEntity : class //EntityBase<TKey>
    {
        #region Fields
        internal DbContext context;
        internal DbSet<TEntity> setEntity;
        //private bool AutoSave;
        protected Boolean Disponsed;
        #endregion

        #region Propeties
        /// <summary>
        /// Entities
        /// </summary>
        protected virtual DbContext Context

        {
            get
            {               
                return context;
            }
        }

        protected virtual DbSet<TEntity> Entity

        {
            get
            {
                if (setEntity == null)
                    //SetEntity = Context.SetCreate<TKey, TEntity>();
                    setEntity = context.Set<TEntity>();

                return setEntity;
            }
        }
        #endregion

        #region Ctor              
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
        public EfRepositoryBase(DbContext context) : this(context, false)
        {
        }

        public EfRepositoryBase(DbContext context, bool useDisponsed)
        {
            this.context = context;
            // this.AutoSave = autoSave;
            this.Disponsed = useDisponsed;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="key">Identifier</param>
        /// <returns>Entity</returns>
        public virtual TEntity GetById(TKey key)
        {
            return this.Entity.Find(key);
        }



        public virtual IEnumerable<TEntity> Get()
        {
            return this.Entity.ToArray();
        }

        //public virtual async Task<IEnumerable<TEntity>> GetAsync()
        //{
        //    return await this.Entity.ToArrayAsync();
        //}

        public virtual IQueryResponse<TEntity> Get(QueryRequest queryRequest)
        {
            IQueryable<TEntity> queryable = this.Entity;

            //queryable = queryable.ApplyWhere(queryRequest);

            //queryable = queryable.ApplyOrdering(queryRequest);

            return queryable.Paging(queryRequest);
        }

        //public virtual async Task<IQueryResponse<TEntity>> GetAsync(IQueryRequest queryRequest)
        //{
        //    IQueryable<TEntity> queryable = this.Entity;

        //    queryable = queryable.ApplyWhere(queryRequest);

        //    queryable = queryable.ApplyOrdering(queryRequest);

        //    return await queryable.PagingAsync(queryRequest);
        //}


        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Insert(TEntity entity)
        {
            //IAuditedCreating entityCreating = entity as IAuditedCreating;
            //if (entityCreating != null)
            //{
            //    entityCreating.Created = System.DateTime.UtcNow;
            //    entityCreating.CreatedBy = "grodriguez";//TODO: Usuario Fijo por ahora, se debe buscar en el identity o recibirlo como parametro;
            //}

            this.Entity.Add(entity);
        }

        ///// <summary>
        ///// Insert entity
        ///// </summary>
        ///// <param name="entity">Entity</param>
        //public virtual async Task InsertAsync(TEntity entity)
        //{
        //    //IAuditedCreating entityCreating = entity as IAuditedCreating;
        //    //if (entityCreating != null)
        //    //{
        //    //    entityCreating.Created = System.DateTime.UtcNow;
        //    //    entityCreating.CreatedBy = "grodriguez";//TODO: Usuario Fijo por ahora, se debe buscar en el identity o recibirlo como parametro;
        //    //}

        //    await this.Entity.AddAsync(entity);
        //}


        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Update(TEntity entity)
        {
            //Entities.Attach(entity);

            //this.Context.Entry(entity).State = EntityState.Modified           

            //IAuditedUpdating entityUpdating = entity as IAuditedUpdating;
            //if (entityUpdating != null)
            //{
            //    entityUpdating.LastModified = System.DateTime.UtcNow;
            //    entityUpdating.LastModifiedBy = "grodriguez";//TODO: Usuario Fijo por ahora, se debe buscar en el identity o recibirlo como parametro
            //}

            // this.Context.SetModified<TKey, TEntity>(entity);
            //  this._context.SaveChanges();

            context.Entry<TEntity>(entity).State = EntityState.Modified;
        }


        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Delete(TEntity entity)
        {

            //this.Context.SetUnchanged<TKey, TEntity>(entity);

            //this._context.SaveChanges();

            context.Entry<TEntity>(entity).State = EntityState.Deleted;
        }

        #endregion
        #region Commit
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        //public async Task<int> SaveChangesAsync()
        //{
        //    return await this.Context.SaveChangesAsync();
        //}

        #endregion
        #region Disposed
        public void Dispose()
        {
            if (!this.Disponsed)
            {
                this.context.Dispose();

                this.Disponsed = true;
            }
        }
        #endregion
    }
}