

using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LibraryManagmentSystem.DataLayer.Entities;
[Table("modules")]
public class Module:BaseEntity
{
    public long Id { get; set; }
    public required string ShortName { get; set; }
    public required string FullName { get; set; }
    public DateTime CreateDate { get; set; } 
    public DateTime? UpdateDate { get; set; }
    public int StateId { get; set; }
    
    [InverseProperty("Modules")]
    [ForeignKey("StateId")]

    public virtual EnumState? State { get; set; }
 
    [InverseProperty("Module")]
    public virtual List<RoleModule>? RoleModules { get; set; }
}
