

using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LibraryManagmentSystem.DataLayer.Entities;
[Table("user_roles")]
public class UserRole : BaseEntity
{
    public long Id { get; set; }
    public long RoleId { get; set; }
    [JsonIgnore]
    [InverseProperty("UserRoles")]
    [ForeignKey("RoleId")]
    public virtual Role? Role { get; set; }
    public long UserId { get; set; }
    [JsonIgnore]
    [InverseProperty("UserRoles")]
    [ForeignKey("UserId")]
    public virtual User? User { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
   
}
