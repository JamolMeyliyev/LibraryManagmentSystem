

namespace LibraryManagmentSystem.DataLayer.Entities;

public class Language
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.UtcNow;
    public DateTime UpdateDate { get; set; }
    public int StateId { get; set; }
    public EnumState? State { get; set; }
    public bool IsDeleted { get; set; }
}
