using LibraryManagmentSystem.DataLayer.Context;
using LibraryManagmentSystem.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.DataLayer.Repositories;

public interface IRoleRepository : IGenericRepository<Role, long>
{ }
    
