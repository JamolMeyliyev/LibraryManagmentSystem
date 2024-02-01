

using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LibraryManagmentSystem.DataLayer.Entities;
[Table("roles")]
public class Role:BaseEntity
{
    public long Id { get; set; }
    public required string ShortName { get; set; }
    public required string FullName { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public int StateId { get; set; }
    [JsonIgnore]
    [InverseProperty("Roles")]
    [ForeignKey("StateId")]
    public virtual EnumState? State { get; set; }
    [JsonIgnore]
    [InverseProperty("Role")]
    public virtual List<RoleModule>? RoleModules { get; set; }
    [JsonIgnore]
    [InverseProperty("Role")]
    public List<UserRole>? UserRoles { get; set; }   
}
