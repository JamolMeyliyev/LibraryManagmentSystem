

namespace LibraryManagmentSystem.LogicLayer.Models; 
public class UpdateRoleModel
{
    public long Id { get; set; }
    public  string? ShortName { get; set; }
    public  string? FullName { get; set; }
    public int? NewStateId { get; set; }
    public List<long>? EditModules { get; set; }
}
