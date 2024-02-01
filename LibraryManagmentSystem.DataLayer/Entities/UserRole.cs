

using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagmentSystem.DataLayer.Entities;
[Table("user_roles")]
public class UserRole:BaseEntity
{
    public long Id { get; set; }
    public long RoleId { get; set; }
    public virtual Role? Role { get; set; }
    public long UserId { get; set; }
    public virtual User? User { get; set; }
    public DateTime CreateDate { get; set; } 
    public DateTime? UpdateDate { get; set; }
    public int StateId { get; set; }
    public virtual EnumState? State { get; set; }
}
