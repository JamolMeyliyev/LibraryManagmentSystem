using AutoMapper;
using LibraryManagmentSystem.DataLayer.Entities;
using LibraryManagmentSystem.LogicLayer.Models;

namespace LibraryManagmentSystem.LogicLayer.Mapper;

public class RoleToReturnRoleModelMapper : Profile
{
    public RoleToReturnRoleModelMapper() 
    {
        CreateMap<Role, ReturnRoleModel>()
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State!.FullName))
            .ForMember(dest => dest.Modules,
            opt => opt.MapFrom(src => src.RoleModules != null ? src.RoleModules.Select(rm => rm.Module.FullName)
            .ToList() : new List<string>()));
        CreateMap<Role, TableReturnRoleModel>()
         .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State!.FullName));
         

    }


}
