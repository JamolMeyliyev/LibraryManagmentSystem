

using LibraryManagmentSystem.DataLayer.Entities;

namespace LibraryManagmentSystem.LogicLayer.Models;

public class UpdateModuleModel
{
    public string? ShortName { get; set; }
    public string? FullName { get; set; }
    public int? NewStateId { get; set; }
    
}
