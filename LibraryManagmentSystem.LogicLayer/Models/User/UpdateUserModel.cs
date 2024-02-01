

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagmentSystem.LogicLayer.Models;

public class UpdateUserModel
{
    public long Id { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Password { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string UserName { get; set; }
    public int StatusId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public Dictionary<long,bool>? UserRoles { get; set; }
}