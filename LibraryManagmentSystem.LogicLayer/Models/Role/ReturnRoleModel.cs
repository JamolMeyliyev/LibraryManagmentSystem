﻿

using LibraryManagmentSystem.DataLayer.Entities;

namespace LibraryManagmentSystem.LogicLayer.Models; 
public class ReturnRoleModel
{
    public long Id { get; set; }
    public required string ShortName { get; set; }
    public required string FullName { get; set; }
    public DateTime CreateDate { get; set; } 
    public DateTime? UpdateDate { get; set; }
    public int StateId { get; set; }
    public required string State { get; set; }
    public List<string> Modules { get; set; } = new List<string>();
    
}