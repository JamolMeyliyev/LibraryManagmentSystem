using LibraryManagmentSystem.LogicLayer.Models;


namespace LibraryManagmentSystem.LogicLayer.Services;

public interface IAccountService
{
    ValueTask RegistrationAsync(RegistrationModel model);
    ValueTask<TokenReturnModel> LoginIn(SignInModel model);
    ValueTask<ReturnUserModel> VerifyingSmsCode(string smsCode, string phoneNumber);

}
