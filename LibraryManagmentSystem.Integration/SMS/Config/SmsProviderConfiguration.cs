

namespace LibraryManagmentSystem.Integration.SMS;

public class SmsProviderConfiguration
{
    public required string AccountLogin { get; set; }
    public required string AccountPassword { get; set; }
    public required string BaseUri { get; set; }
    public required string LoginUri { get; set; }
    public required string SendSmsUri { get; set; }
    public required string CallbackUrl { get; set; }
}
