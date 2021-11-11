using DataCashFlow.Models;
using DataCashFlow.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCashFlow.UnitOfWork
{
    public interface IBaseUnitOfWork
    {
        IRepositoryBase<BaseModel> RepositoryBase { get; set; }
        void Commit();
    }
}
