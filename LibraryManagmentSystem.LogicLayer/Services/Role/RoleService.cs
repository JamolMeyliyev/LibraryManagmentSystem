

using AutoMapper;
using LibraryManagmentSystem.DataLayer.Entities;
using LibraryManagmentSystem.DataLayer.Repositories;
using LibraryManagmentSystem.LogicLayer.Models;
using Microsoft.EntityFrameworkCore;
namespace LibraryManagmentSystem.LogicLayer.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _repos;
    private readonly IRoleModuleRepository _roleModuleRepos;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IModuleRepository _moduleRepos;
    private readonly IMapper _mapper;
    public RoleService(IRoleRepository repos, IRoleModuleRepository roleModuleRepos,
        IUnitOfWork unitOfWork,IMapper mapper, IModuleRepository moduleRepos)
    {
        _repos = repos;
        _roleModuleRepos = roleModuleRepos;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _moduleRepos = moduleRepos;
    }

    public async ValueTask<long> CreateAsync(CreateRoleModel createModel)
    {
        using (var transaction = _unitOfWork.BeginTransaction())
        {
            try
            {
                var entity = _mapper.Map<Role>(createModel);
                var role = await _repos.InsertAsync(entity); 
                if(createModel.Modules is not null)
                {
                    foreach (var moduleId in createModel.Modules)
                    {
                        var roleModule = new RoleModule()
                        {
                            CreateDate = DateTime.UtcNow,
                            RoleId = role.Id,
                            ModuleId = moduleId,
                            
                        };
                        await _roleModuleRepos.InsertAsync(roleModule);
                    }
                }
                transaction.Commit();
                return role.Id;

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
        
        
        using (var transaction = _unitOfWork.BeginTransaction())
        {
            try
            {
                var role = await _repos.SelectByIdWithDetailsAsync(s => s.Id == id, new string[] { "State","RoleModules" });
                if(role == null)
                {
                    throw new NotFoundException("role");
                }
                if(role.RoleModules!= null)
                {
                    foreach (var module in role.RoleModules)
                    {
                        module.IsDeleted = true;
                        await _roleModuleRepos.UpdateAsync(module);
                    }
                }
                
                role.IsDeleted = true;
                await _repos.UpdateAsync(role);

                transaction.Commit();
                return id;

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception();
            }
        }
    }

    public async ValueTask<ReturnRoleModel> GetAsync(long id)
    {
        var role = await _repos.SelectByIdWithDetailsAsync(s => s.Id == id, new string[] { "State", "RoleModules" });
        if (role == null)
        {
            throw new NotFoundException("role");
        }
        role.RoleModules = await _roleModuleRepos.SelectAll()
            .Where(s => s.RoleId == role.Id).Where(s => s.IsDeleted == false).Include(s => s.Module)
            .ToListAsync();

        return _mapper.Map<ReturnRoleModel>(role);  
        
    }

    public async ValueTask<IEnumerable<TableReturnRoleModel>> GetListAsync(FilterRoleListModel filter)
    {
        var list = await _repos.SelectAll().Include(s => s.State).ToListAsync();


        return _mapper.Map<IEnumerable<TableReturnRoleModel>>(list);
    }


    public async ValueTask<long> UpdateAsync(UpdateRoleModel updateModel)
    {
        var entity = await _repos.SelectByIdWithDetailsAsync(s => s.Id == updateModel.Id, new string[] { "State", "RoleModules" });
        if (entity == null)
        {
            throw new NotFoundException("role");
        }
        entity.UpdateDate = DateTime.UtcNow;
        entity.StateId = updateModel.NewStateId ?? entity.StateId;
        entity.ShortName = updateModel.ShortName ?? entity.ShortName;
        entity.FullName = updateModel.FullName ?? entity.FullName;
        if(updateModel.EditModules!= null && updateModel.EditModules.Count > 0)
        {
            
            var createdModelIds = new List<long>(); 
            if(entity.RoleModules is not null && entity.RoleModules.Count >0)
            {
                foreach (var created in entity.RoleModules)
                {
                    createdModelIds.Add(created.ModuleId);
                }
            }
            
            var cr = updateModel.EditModules.Except(createdModelIds).ToList();
            var del = createdModelIds.Except(updateModel.EditModules).ToList();

            foreach(var d in del)
            {
                var roleModule = await _roleModuleRepos.SelectByIdWithDetailsAsync(s => s.ModuleId == d && s.RoleId == entity.Id,new string[] {"State"});
                await _roleModuleRepos.DeleteAsync(roleModule);
            }
            foreach(var c in cr)
            {
                var roleModule = new RoleModule()
                {
                    RoleId = entity.Id,
                    ModuleId = c,
                    CreateDate = DateTime.UtcNow,
                    IsDeleted = false,
                    StateId = 1

                };
                await _roleModuleRepos.InsertAsync(roleModule);
                
            }
        }
        
        await _repos.UpdateAsync(entity);

        return entity.Id;
    }
}
