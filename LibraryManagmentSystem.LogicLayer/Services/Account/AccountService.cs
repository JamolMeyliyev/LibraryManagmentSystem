using AutoMapper;
using LibraryManagmentSystem.DataLayer.Context;
using LibraryManagmentSystem.DataLayer.Entities;

using LibraryManagmentSystem.Integration.SMS;
using LibraryManagmentSystem.LogicLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;


namespace LibraryManagmentSystem.LogicLayer.Services;

public class AccountService : IAccountService
{
    private readonly ITokenService _tokenService;
    private readonly LibraryDbContext _context;
    private readonly IMapper _mapper;
    private readonly IMemoryCache _cache;
    private readonly ISmsService _smsService;
    private readonly IUserServive _userRepos;
    public AccountService(ITokenService tokenService, LibraryDbContext context,
        IMapper mapper, IMemoryCache cache, ISmsService smsService, IUserServive userRepos)
    {
        _tokenService = tokenService;
        _context = context;
        _mapper = mapper;
        _cache = cache;
        _smsService = smsService;
        _userRepos = userRepos;
    }
    public async ValueTask<TokenReturnModel> LoginIn(SignInModel model)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.PhoneNumber == model.PhoneNumber);
        if (user == null)
        {
            throw new NotFoundException("user");
        }

        var result = new PasswordHasher<User>().VerifyHashedPassword(user, user.Password, model.Password);
        if (result != PasswordVerificationResult.Success)
        {
            throw new LoginValidationException();
        }
        return await _tokenService.GenerateTokenAsync(user);

    }


    public async ValueTask RegistrationAsync(RegistrationModel model)
    {

        var isUsernameExists = await _context.Users.FirstOrDefaultAsync(u => u.PhoneNumber == model.PhoneNumber);
        if (isUsernameExists is not null)
        {
            throw new EntityExistsException("User");
        }
        string randCode = await _smsService.SendSmsMessageAsync(model.PhoneNumber);
        model.SmsCode = randCode;


        SaveSmsCodeCache(model.PhoneNumber, JsonConvert.SerializeObject(model));
    }



    public async ValueTask<ReturnUserModel> VerifyingSmsCode(string smsCode, string phoneNumber)
    {
        if (!_cache.TryGetValue(phoneNumber, out string? cacheModel))
        {
            throw new Exception("vaq tugadi qayta yuboring");
        }
        var model = JsonConvert.DeserializeObject<RegistrationModel>(cacheModel ?? string.Empty);
        if (model is null)
        {
            throw new NotFoundException("Model");
        }

        if (model.SmsCode != smsCode)
        {
            throw new Exception("sms xato");
        }

        var user = _mapper.Map<User>(model);

        user.Password = new PasswordHasher<User>().HashPassword(user, model.Password);

        //await _userRepos.CreateAsync(user);

        _cache.Remove(user.PhoneNumber);

        return _mapper.Map<ReturnUserModel>(user);
    }



    private void SaveSmsCodeCache(string key, string value)
    {
        _cache.Set(key, value, new MemoryCacheEntryOptions()
        {
            SlidingExpiration = TimeSpan.FromMinutes(3)
        });
    }
}

