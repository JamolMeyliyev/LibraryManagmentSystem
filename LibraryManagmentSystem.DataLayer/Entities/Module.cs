

namespace LibraryManagmentSystem.DataLayer.Entities;

public class Module
{
    public long Id { get; set; }
    public required string ShortName { get; set; }
    public required string FullName { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.Now;
    public DateTime UpdateDate { get; set; }
    public int StateId { get; set; }
    public EnumState? State { get; set; }
    public bool IsDeleted { get; set; }
}
