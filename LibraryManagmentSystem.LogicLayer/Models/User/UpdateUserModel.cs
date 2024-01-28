

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagmentSystem.LogicLayer.Models;

public class UpdateUserModel
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}
public class UpdatePassword
{
    public string Password { get; set; } = null!;

    [Compare("Password")]
    public string ConfirmPassword { get; set; } = null!;
    public string SmsCode { get; set; } = null!;
}

public class UpdatePhoneNumber
{
    public string PhoneNumber { get; set; } = null!;
}
