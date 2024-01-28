

using edu.DataAccess.Context;

using edu.DataAccess.Enums;
using edu.DataAccess.Repositories.Generic;
using edu_center_api.Entities;

namespace edu.DataAccess.Repositories;

public class UserRepository : GenericRepository<User, long>, IUserRepository
{
    public UserRepository(EducationContext context) : base(context)
    {

    }
    public override async ValueTask<User> DeleteAsync(User entity)
    {
        entity.StateId = (int)UserEnumStatus.Deleted;
        await this.SaveChangesAsync();
        return await this.SelectByIdAsync(entity.Id);
    }

}
