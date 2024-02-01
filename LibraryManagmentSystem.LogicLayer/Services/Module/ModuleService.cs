using AutoMapper;
using LibraryManagmentSystem.DataLayer.Entities;
using LibraryManagmentSystem.DataLayer.Repositories;

using LibraryManagmentSystem.LogicLayer.Models;
using LibraryManagmentSystem.LogicLayer.Validators;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagmentSystem.LogicLayer.Services;

public class ModuleService : IModuleService
{
    private readonly IModuleRepository _repos;
    private readonly IMapper _mapper;
    
    public ModuleService(IModuleRepository repos,IMapper mapper)
    {
        _repos = repos;
        _mapper = mapper;
    }
    public async ValueTask<long> CreateModelAsync(CreateModuleModel createModel)
    {
        var validator = new ValidatorForCreateModuleModel();
        var result = validator.Validate(createModel);
        if(!result.IsValid)
        {
            throw new InvalidOperationException();
        }
        var module = _mapper.Map<Module>(createModel);
        var entity = await _repos.InsertAsync(module);
        return entity.Id;
    }

    public async ValueTask<long> DeleteModelAsync(long id)
    {
        var entity = await _repos.SelectByIdAsync(id);
        if (entity is null)
        {
            throw new InvalidOperationException();
        }
        await _repos.DeleteAsync(entity);
        return entity.Id;
    }

    public async ValueTask<IEnumerable<TableReturnModuleModel>> GetListAsync(FilterModuleListModel filter)
    {

        var list = await _repos.SelectAll().Include(s => s.State).ToListAsync();
        return _mapper.Map<IEnumerable<TableReturnModuleModel>>(list);
    }

    public async ValueTask<ReturnModuleModel> GetReturnModuleAsync(long id)
    {
        var entity = await _repos.SelectByIdWithDetailsAsync(s => s.Id == id, new string[] { "State" });
        if (entity is null)
        {
            throw new InvalidOperationException();
        }
        return _mapper.Map<ReturnModuleModel>(entity);
    }

    

    public async ValueTask<long> UpdateModelAsync(UpdateModuleModel updateModel,long id)
    {
        var entity = await _repos.SelectByIdWithDetailsAsync(s => s.Id == id, new string[] { "State" });
        if (entity is null)
        {
            throw new InvalidOperationException();
        }
        entity.UpdateDate = DateTime.UtcNow;
        entity.StateId = updateModel.NewStateId ?? entity.StateId;
        entity.ShortName = updateModel.ShortName ?? entity.ShortName;
        entity.FullName= updateModel.FullName ?? entity.FullName;
        
        await _repos.UpdateAsync(entity);
        return entity.Id;
    }
}
