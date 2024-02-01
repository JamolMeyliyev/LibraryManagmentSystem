using LibraryManagmentSystem.DataLayer.Context;
using LibraryManagmentSystem.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;


namespace LibraryManagmentSystem.DataLayer.Repositories;

public class RoleRepository : GenericRepository<Role, long>, IRoleRepository
{

    public RoleRepository(LibraryDbContext context) : base(context)
    {

    }
   

}
