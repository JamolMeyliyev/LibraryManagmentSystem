using AutoMapper;
using LibraryManagmentSystem.DataLayer.Entities;
using LibraryManagmentSystem.LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.LogicLayer.Mapper;

public class UpdateModuleToModuleMapper:Profile
{
   public UpdateModuleToModuleMapper() 
    {
        CreateMap<UpdateModuleModel,Module>()
            .ForMember(s => s.UpdateDate, s => s.MapFrom(m => DateTime.UtcNow))
            
            
            .ForMember(dest => dest.ShortName, opt => opt.Condition(src => src.ShortName != null))
            .ForMember(dest => dest.FullName, opt => opt.Condition(src => src.FullName != null))
            .ForMember(dest => dest.StateId, opt => opt.Condition(src => src.NewStateId.HasValue))
            .AfterMap((src, dest) =>
            {
                if (src.NewStateId.HasValue)
                {
                    dest.StateId = src.NewStateId.Value;  
                }
            });
    }
}
