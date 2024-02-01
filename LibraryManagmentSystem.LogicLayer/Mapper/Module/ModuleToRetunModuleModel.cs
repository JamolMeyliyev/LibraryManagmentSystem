using AutoMapper;
using LibraryManagmentSystem.DataLayer.Entities;
using LibraryManagmentSystem.LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.LogicLayer.Mapper;

public class ModuleToRetunModuleModel:Profile
{
  public  ModuleToRetunModuleModel()
    { 
        CreateMap<Module,ReturnModuleModel>()
            .ForMember(s => s.State, p => p.MapFrom(s => s.State!.FullName));
        CreateMap<Module, TableReturnModuleModel>()
                   .ForMember(s => s.State, p => p.MapFrom(s => s.State!.FullName));
    }

}
