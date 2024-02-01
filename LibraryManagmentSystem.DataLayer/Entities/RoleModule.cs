

using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LibraryManagmentSystem.DataLayer.Entities;
[Table("role_modules")]
public class RoleModule:BaseEntity
{
    public long Id { get; set; }
    public long RoleId { get; set; }
    [JsonIgnore]
    [InverseProperty("RoleModules")]
    [ForeignKey("RoleId")]
    public virtual Role? Role { get; set; }
    public long ModuleId { get; set; }
    [JsonIgnore]
    [InverseProperty("RoleModules")]
    [ForeignKey("ModuleId")]
    public virtual Module? Module { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public int StateId { get; set; }
    [JsonIgnore]
    [InverseProperty("RoleModules")]
    [ForeignKey("StateId")]
    public virtual EnumState? State { get; set; }
    

}
