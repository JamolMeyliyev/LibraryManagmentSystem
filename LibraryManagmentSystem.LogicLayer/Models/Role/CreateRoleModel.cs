namespace LibraryManagmentSystem.LogicLayer.Models;

public class CreateRoleModel
{
    public required string ShortName { get; set; }
    public required string FullName { get; set; }
    public List<long>? Modules { get; set; }

    
}
