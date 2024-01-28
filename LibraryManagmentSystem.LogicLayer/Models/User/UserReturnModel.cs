

namespace LibraryManagmentSystem.LogicLayer.Models;

public class UserReturnModel
{
    public int Id { get; set; }
    public int StateId { get; set; }
    public int UserRoleId { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
}
