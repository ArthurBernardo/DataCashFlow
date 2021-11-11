using DataCashFlow.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataCashFlow.Repository
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : BaseModel
    {
        public Context context;
        public DbSet<TEntity> DbSet;

        public RepositoryBase(Context _context)
        {
            context = _context;
            DbSet = _context.Set<TEntity>();
            context.Configuration.LazyLoadingEnabled = true;
        }

        public void Add<T>(T entity) where T : BaseModel
        {
            var _DbSet = context.Set<T>();

            _DbSet.Add(entity);
        }

        public void AddAll<T>(List<T> entity) where T : BaseModel
        {
            var _DbSet = context.Set<T>();

            _DbSet.AddRange(entity);
        }

        public void Delete<T>(T entity) where T : BaseModel
        {
            var _DbSet = context.Set(typeof(T));

            if (context.Entry<TEntity>(entity as TEntity).State == System.Data.Entity.EntityState.Detached)
            {
                _DbSet.Attach(entity);
            }

            _DbSet.Remove(entity);
        }

        public void Dispose()
        {
            DbSet = null;
            context.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Edit<T>(T entity) where T : BaseModel
        {
            context.Entry<TEntity>(entity as TEntity).State = System.Data.Entity.EntityState.Modified;
        }

        public void EditAll<T>(List<T> entity) where T : BaseModel
        {
            foreach (var item in entity)
            {
                context.Entry<TEntity>(item as TEntity).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public virtual T FirstOrDefault<T>(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null) where T : BaseModel
        {


            var _DbSet = context.Set(typeof(T));

            IQueryable<T> query = (System.Linq.IQueryable<T>)_DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return orderBy(query).FirstOrDefault();
            }
            else
            {
                return query.FirstOrDefault();
            }

        }

        public virtual List<T> Get<T>(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] includes) where T : BaseModel
        {

            var _DbSet = context.Set<T>();

            IQueryable<T> query = (System.Linq.IQueryable<T>)_DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }

        }
    }
}
