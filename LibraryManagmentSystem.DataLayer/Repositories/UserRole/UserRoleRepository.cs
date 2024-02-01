

using LibraryManagmentSystem.DataLayer.Context;
using LibraryManagmentSystem.DataLayer.Entities;

namespace LibraryManagmentSystem.DataLayer.Repositories;

public class UserRoleRepository : GenericRepository<UserRole, long>, IUserRoleRepository
{
    public UserRoleRepository(LibraryDbContext dbContext) : base(dbContext)
    {
    }

}
