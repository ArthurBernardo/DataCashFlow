using DataCashFlow.Models;
using DataCashFlow.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCashFlow.UnitOfWork
{
    public class BaseUnitOfWork : IDisposable, IBaseUnitOfWork
    {
        private readonly Context _context;
        private bool _disposed;

        public IRepositoryBase<BaseModel> RepositoryBase { get; set; }

        public BaseUnitOfWork()
        {
            _context = new Context();
            RepositoryBase = new RepositoryBase<BaseModel>(_context);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Clear(true);
            GC.SuppressFinalize(this);

        }
        private void Clear(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)

                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
        ~BaseUnitOfWork()
        {
            Clear(false);
        }
    }
}
