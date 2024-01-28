



using LibraryManagmentSystem.DataLayer.Entities;
using LibraryManagmentSystem.LogicLayer.Models;

namespace LibraryManagmentSystem.LogicLayer.Services;

public interface ITokenService
{
    ValueTask<TokenReturnModel> GenerateTokenAsync(User user);
}
