

namespace LibraryManagmentSystem.DataLayer.Entities;

public class Role
{
    public long Id { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.Now;
    public DateTime UpdateDate { get; set; }
    public int StateId { get; set; }
    public EnumState? State { get; set; }
    public bool IsDeleted { get; set; }

}
