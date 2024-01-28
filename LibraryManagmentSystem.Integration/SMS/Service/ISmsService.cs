


namespace LibraryManagmentSystem.Integration.SMS;

public interface ISmsService
{
    ValueTask<string> GetSmsTokenAsync(string login, string password, string basUri, string loginUri);
    ValueTask<string> SendSmsMessageAsync(string phoneNumber);
    
}
