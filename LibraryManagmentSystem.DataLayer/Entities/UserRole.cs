

namespace LibraryManagmentSystem.DataLayer.Entities;

public class UserRole
{
    public long Id { get; set; }
    public long RoleId { get; set; }
    public Role Role { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.UtcNow;
    public DateTime UpdateDate { get; set; }
    public int StateId { get; set; }
    public EnumState? State { get; set; }
}
