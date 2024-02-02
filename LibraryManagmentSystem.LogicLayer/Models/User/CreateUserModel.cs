

using LibraryManagmentSystem.DataLayer.Entities;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagmentSystem.LogicLayer.Models;

public class CreateUserModel
{
    public required string PhoneNumber { get; set; }
    public required string Password { get; set; }

    [Compare("Password")]
    public required string ConfirmPassword { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string UserName { get; set; }
    public List<long>? Roles { get; set; }
}
