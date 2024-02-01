

using LibraryManagmentSystem.DataLayer.Context;
using LibraryManagmentSystem.DataLayer.Entities;

namespace LibraryManagmentSystem.DataLayer.Repositories;
public class RoleModuleRepository : GenericRepository<RoleModule, long>, IRoleModuleRepository
{
    public RoleModuleRepository(LibraryDbContext dbContext) : base(dbContext)
    {

    }
}
