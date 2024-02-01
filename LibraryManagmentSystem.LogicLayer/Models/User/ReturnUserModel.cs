

using LibraryManagmentSystem.DataLayer.Entities;

namespace LibraryManagmentSystem.LogicLayer.Models;

public class ReturnUserModel
{
    public long Id { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Password { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string UserName { get; set; }
    public long StateId { get; set; }
    public required string State { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public List<string>? Roles { get; set; }
}
