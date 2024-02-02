using AutoMapper;
using LibraryManagmentSystem.DataLayer.Entities;
using LibraryManagmentSystem.DataLayer.Repositories;

using LibraryManagmentSystem.LogicLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagmentSystem.LogicLayer.Services;

public class UserService : IUserServive
{
    private readonly IUserRepository _repos;
    private readonly IUserRoleRepository _userRoleRepos;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public UserService(
        IUserRepository repos,
        IMapper mapper, 
        IUnitOfWork unitOfWork,
        IUserRoleRepository userRoleRepos)
    {
        _repos = repos;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _userRoleRepos = userRoleRepos;
    }
    public async ValueTask<long> CreateAsync(CreateUserModel createModel)
    {
        var entity = _mapper.Map<User>(createModel);
        using (var transaction = _unitOfWork.BeginTransaction())
        {
            try
            {
              
                var user = await _repos.InsertAsync(entity);
                if(createModel.Roles is not null && createModel.Roles.Count > 0)
                {
                    foreach(var roleId in createModel.Roles)
                    {
                        var roleEntity = new UserRole()
                        {
                            RoleId = roleId,
                            UserId = user.Id,
                            StateId = 1,
                            IsDeleted = false,
                            CreateDate= DateTime.UtcNow,
                        };
                        await _userRoleRepos.InsertAsync(roleEntity);
                        
                    }
                }
                await transaction.CommitAsync();
                return user.Id;

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception();
            }
        }
    }

    public async ValueTask<long> DeleteAsync(long id)
    {
        var entity = await _repos.SelectByIdAsync(id);
        if(entity == null)
        {
            throw new NotFoundException("user");
        }
        await _repos.DeleteAsync(entity);

        if(entity.UserRoles is not null && entity.UserRoles!.Count > 0 )
        {
            foreach (var role in entity.UserRoles)
            {
                await _userRoleRepos.DeleteAsync(role);
            }
        }
        
        return entity.Id;

    }

    public async ValueTask<UserListModel> GetListAsync(UserFilterModel filter)
    {
        var list = await _repos.SelectAll().Include(s => s.State).ToListAsync();
        return _mapper.Map<UserListModel>(list);
    }

    public async ValueTask<ReturnUserModel> GetReturnAsync(long id)
    {
        var entity = await _repos.SelectByIdAsync(id);
        if (entity == null)
        {
            throw new NotFoundException("user");
        }
        return _mapper.Map<ReturnUserModel>(entity);
    }

  
    public async ValueTask<long> UpdateAsync(UpdateUserModel updateModel)
    {

        var entity = _mapper.Map<User>(updateModel);
        await _repos.UpdateAsync(entity);
        return entity.Id;
        
    }
}
