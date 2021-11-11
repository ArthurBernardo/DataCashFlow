using DataCashFlow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataCashFlow.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : BaseModel
    {
        void Add<T>(T entity) where T : BaseModel;

        void AddAll<T>(List<T> entity) where T : BaseModel;

        void Edit<T>(T entity) where T : BaseModel;

        void EditAll<T>(List<T> entity) where T : BaseModel;

        void Delete<T>(T entity) where T : BaseModel;

        List<T> Get<T>(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] includes) where T : BaseModel;

        T FirstOrDefault<T>(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null) where T : BaseModel;
    }
}
