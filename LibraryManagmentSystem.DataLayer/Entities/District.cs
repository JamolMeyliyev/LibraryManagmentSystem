

namespace LibraryManagmentSystem.DataLayer.Entities;

public class District
{
    public long Id { get; set; }
    public required string ShortName { get; set; }
    public required string FullName { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.UtcNow;
    public DateTime UpdateDate { get; set; }
    public long RegionId { get; set; }
    public int StateId { get; set; }
    public Region Region { get; set; }
    public EnumState? State { get; set; }
    public bool IsDeleted { get; set; }

}
