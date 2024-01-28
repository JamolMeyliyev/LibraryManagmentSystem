using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.LogicLayer.Models;

public class SignInModel
{

    public required string PhoneNumber { get; set; } = null!;
    public required string Password { get; set; } = null!;
}

