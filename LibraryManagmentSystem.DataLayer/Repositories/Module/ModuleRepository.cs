

using LibraryManagmentSystem.DataLayer.Context;
using LibraryManagmentSystem.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagmentSystem.DataLayer.Repositories;

public class ModuleRepository : GenericRepository<Module,long>, IModuleRepository
{
   
    public ModuleRepository(LibraryDbContext context) : base(context)
    {
        
    }

  
}
