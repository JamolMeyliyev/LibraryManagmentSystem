

using System.Text.Json.Serialization;

namespace LibraryManagmentSystem.Integration.SMS;

public class SmsApiResponseModel
{
    [JsonPropertyName("message")]
    public string? Message { get; set; }


    [JsonPropertyName("data")]
    public TokenData? Data { get;set; }


    [JsonPropertyName("token_type")]
    public string? TokenType { get; set; }
}
public class TokenData
{
    [JsonPropertyName("token")]
    public string Token { get; set; }
}
