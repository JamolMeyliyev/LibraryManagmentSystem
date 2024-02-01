

using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LibraryManagmentSystem.DataLayer.Entities;

public class EnumState
{
    public int Id { get; set; }
    public required string ShortName { get; set; }
    public required string FullName { get; set; }
    public bool IsDeleted { get; set; }
    [JsonIgnore]
    [InverseProperty("State")]
    public virtual List<Module>? Modules { get; set; }
    [JsonIgnore]
    [InverseProperty("State")]
    public virtual List<User>? Users { get; set; }
    [JsonIgnore]
    [InverseProperty("State")]
    public virtual List<UserRole> UserRoles { get; set; }
    [InverseProperty("State")]
    public virtual List<Role> Roles { get; set; }
    [JsonIgnore]
    [InverseProperty("State")]
    public virtual List<RoleModule> RoleModules { get; set; }


}
