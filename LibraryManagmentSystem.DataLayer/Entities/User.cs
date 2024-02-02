

using Microsoft.EntityFrameworkCore.Metadata.Internal;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibraryManagmentSystem.DataLayer.Entities;
[Table("users")]
public partial class User:BaseEntity
{
    public long Id { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Password { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string UserName { get; set; }
    public int StateId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    [JsonIgnore]
    [InverseProperty("Users")]
    [ForeignKey("StateId")]
    public virtual EnumState? State { get; set; }

    [JsonIgnore]
    [InverseProperty("User")]
    public virtual List<UserRole>? UserRoles { get; set; }
}


