

using Microsoft.EntityFrameworkCore.Metadata.Internal;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace LibraryManagmentSystem.DataLayer.Entities;
public partial class User {
    public long Id { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Password { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public int StatusId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public bool IsDeleted { get; set; }
    public UserStatus UserStatus { get; set; }
}


