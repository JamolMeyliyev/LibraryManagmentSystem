

using AutoMapper;
using LibraryManagmentSystem.DataLayer.Entities;
using LibraryManagmentSystem.LogicLayer.Models;

namespace LibraryManagmentSystem.LogicLayer.Mapper;

public class CreateUserToUserMapper:Profile
{
    public CreateUserToUserMapper()
    {
        CreateMap<CreateUserModel, User>()
            .ForMember(s => s.IsDeleted, s => s.MapFrom(p => false))
            .ForMember(s => s.CreatedDate, p => p.MapFrom(s => DateTime.UtcNow))
            .ForMember(s => s.StateId, s => s.MapFrom(s => 1))
            .ForMember(s => s.LastName, s => s.MapFrom(p => p.LastName))
            .ForMember(s => s.PhoneNumber, p => p.MapFrom(s => s.PhoneNumber))
            .ForMember(s => s.UserName, s => s.MapFrom(s => s.UserName))
            .ForMember(s => s.Password, s => s.MapFrom(s => s.Password));

    }
}
