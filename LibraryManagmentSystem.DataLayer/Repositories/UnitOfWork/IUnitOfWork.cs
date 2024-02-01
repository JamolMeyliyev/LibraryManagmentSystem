using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.DataLayer.Repositories;

public interface IUnitOfWork
{

    public IDbContextTransaction BeginTransaction();
    public void Save();
    public void Commit();
    public void Rollback();
   
}
