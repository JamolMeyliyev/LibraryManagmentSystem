using LibraryManagmentSystem.LogicLayer.Models;


namespace LibraryManagmentSystem.LogicLayer.Services;

public interface IRoleService
{
    ValueTask<IEnumerable<TableReturnRoleModel>> GetListAsync(FilterRoleListModel filter);
    ValueTask<ReturnRoleModel> GetAsync(long id);
    ValueTask<long> CreateAsync(CreateRoleModel createModel);
    ValueTask<long> UpdateAsync(UpdateRoleModel updateModel);
    ValueTask<long> DeleteAsync(long id);
    
}
