

using LibraryManagmentSystem.LogicLayer.Models;

namespace LibraryManagmentSystem.LogicLayer.Services;

public interface IUserServive
{
    ValueTask<UserListModel> GetListAsync(UserFilterModel filter);
    ValueTask<ReturnUserModel> GetReturnAsync(long id);
    ValueTask<long> CreateAsync(CreateUserModel createModel);
    ValueTask<long> UpdateAsync(UpdateUserModel updateModel);
    ValueTask<long> DeleteAsync(long id);
   
}
