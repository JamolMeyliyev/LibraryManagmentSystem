

using LibraryManagmentSystem.DataLayer.Context;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagmentSystem.DataLayer.Repositories;

public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryDbContext _context;
        public UnitOfWork(LibraryDbContext context)
        {

            _context = context;
            
        }
       
       
        //public SspUis.DataLayer.EfCode.EfCoreContext EdocContext { get; }

        public IDbContextTransaction? CurrentTransaction { get => _context.Database.CurrentTransaction; }
       
        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Commit()
        {
            Save();
            if (_context.Database.CurrentTransaction != null)
                _context.Database.CurrentTransaction.Commit();
        }
        public void Rollback()
        {
            if (_context.Database.CurrentTransaction != null)
                _context.Database.CurrentTransaction.Rollback();
        }

    }

