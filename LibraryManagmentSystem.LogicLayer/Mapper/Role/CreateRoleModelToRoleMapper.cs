using AutoMapper;
using LibraryManagmentSystem.DataLayer.Entities;
using LibraryManagmentSystem.LogicLayer.Models;

namespace LibraryManagmentSystem.LogicLayer.Mapper;

public class CreateRoleModelToRoleMapper:Profile
{
    public CreateRoleModelToRoleMapper()
    {
        CreateMap<CreateRoleModel, Role>()
            .ForMember(s => s.IsDeleted,s => s.MapFrom(p => false))
            .ForMember(s => s.CreateDate,p => p.MapFrom(s => DateTime.UtcNow));
    }
     
}
