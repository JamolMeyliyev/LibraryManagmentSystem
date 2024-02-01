


using LibraryManagmentSystem.DataLayer.Context;
using LibraryManagmentSystem.DataLayer.Entities;
using LibraryManagmentSystem.DataLayer.Repositories;

namespace edu.DataAccess.Repositories;

public class UserRepository : GenericRepository<User, long>, IUserRepository
{
    public UserRepository(LibraryDbContext dbContext) : base(dbContext)
    {
    }
}
