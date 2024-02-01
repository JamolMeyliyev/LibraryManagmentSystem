using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.DataLayer.Entities;

public class BaseEntity
{
    [Column("is_deleted")]
    public bool IsDeleted { get; set; }
}
