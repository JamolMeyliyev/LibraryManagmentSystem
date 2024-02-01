using AutoMapper;
using LibraryManagmentSystem.DataLayer.Entities;
using LibraryManagmentSystem.LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.LogicLayer.Mapper;

public class CreateModuleToModuleMapper:Profile
{
   public CreateModuleToModuleMapper()
    {
        CreateMap<CreateModuleModel, Module>()
            .ForMember(s => s.CreateDate, s => s.MapFrom(s => DateTime.UtcNow))
            .ForMember(s => s.IsDeleted, s => s.MapFrom(s => false));
    }

}
