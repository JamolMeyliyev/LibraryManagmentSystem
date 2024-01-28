


using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace LibraryManagmentSystem.Integration.SMS;
public class SmsService : ISmsService
{
    private readonly SmsProviderConfiguration _smsConfig;
    public SmsService(IOptions<SmsProviderConfiguration> smsConfig)
    {
        _smsConfig = smsConfig.Value;
    }

    

    public async ValueTask<string> GetSmsTokenAsync(string login, string password, string basUri, string loginUri)
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri(basUri);
        var request = new HttpRequestMessage(HttpMethod.Post, loginUri);
        var content = new MultipartFormDataContent();

          content.Add(new StringContent(login),"email");
          content.Add(new StringContent(password),"password");

        request.Content = content;

        var response =await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        
        var jsonProviderToken = await response.Content.ReadAsStringAsync();
        if (jsonProviderToken.IsNullOrEmpty())
        {
            throw new Exception();
        }
        var apiResponse = JsonConvert.DeserializeObject<SmsApiResponseModel>(jsonProviderToken);
        if(apiResponse?.Data is null || apiResponse.Data.Token.IsNullOrEmpty())
        {
            throw new Exception();
        }

        return apiResponse.Data.Token;
    }

    public async ValueTask<string> SendSmsMessageAsync(string phoneNumber)
    {

        var randomCode = new Random().Next(1000, 9999);
        var login = _smsConfig.AccountLogin;
        var password = _smsConfig.AccountPassword;
        var baseUri = _smsConfig.BaseUri;
        var loginUri = _smsConfig.LoginUri;
        var sendSmsUri = _smsConfig.SendSmsUri;
        var callBackUrl = _smsConfig.CallbackUrl;

        var smsProviderToken = await GetSmsTokenAsync(login, password, baseUri, loginUri);
    
        var client = new HttpClient();
        client.BaseAddress= new Uri(baseUri);
        var request = new HttpRequestMessage(HttpMethod.Post, sendSmsUri);

        request.Headers.Add("Authorization", $"Bearer {smsProviderToken}");
        var content = new MultipartFormDataContent();
         content.Add(new StringContent(phoneNumber), "mobile_phone");
         content.Add(new StringContent($"{randomCode}"), "message");
         content.Add(new StringContent("4546"), "from");
         content.Add(new StringContent(callBackUrl), "callback_url");

        request.Content = content;

        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        return randomCode.ToString();
    }
}
