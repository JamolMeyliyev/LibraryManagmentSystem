using LibraryManagmentSystem.LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.LogicLayer.Services;

public interface IModuleService
{
    ValueTask<IEnumerable<TableReturnModuleModel>> GetListAsync(FilterModuleListModel filter);
    ValueTask<ReturnModuleModel> GetReturnModuleAsync(long id);
    ValueTask<long> CreateModelAsync(CreateModuleModel createModel);
    ValueTask<long> UpdateModelAsync(UpdateModuleModel updateModel,long id);
    ValueTask<long> DeleteModelAsync(long id);
    
}
