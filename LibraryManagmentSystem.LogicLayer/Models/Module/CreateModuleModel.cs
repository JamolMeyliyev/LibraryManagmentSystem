

using LibraryManagmentSystem.DataLayer.Entities;

namespace LibraryManagmentSystem.LogicLayer.Models;

public class CreateModuleModel
{
   
    public required string ShortName { get; set; }
    public required string FullName { get; set; }
    public int StateId { get; set; }
 
}
