

namespace LibraryManagmentSystem.DataLayer.Entities;

public class RoleModule
{
    public long Id { get; set; }
    public long RoleId { get; set; }
    public Role Role { get; set; }
    public long MouleId { get; set; }
    public Module Module { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.Now;
    public DateTime UpdateDate { get; set; }
    public int StateId { get; set; }
    public EnumState? State { get; set; }
    public bool IsDeleted { get; set; }

}
