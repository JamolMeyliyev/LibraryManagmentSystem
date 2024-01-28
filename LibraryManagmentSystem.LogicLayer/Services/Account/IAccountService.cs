using LibraryManagmentSystem.LogicLayer.Models;


namespace LibraryManagmentSystem.LogicLayer.Services;

public interface IAccountService
{
    ValueTask RegistrationAsync(RegistrationModel model);
    ValueTask<TokenReturnModel> LoginIn(SignInModel model);
    ValueTask<UserReturnModel> VerifyingSmsCode(string smsCode, string phoneNumber);

}
