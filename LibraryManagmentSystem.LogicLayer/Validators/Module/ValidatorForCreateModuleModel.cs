

using FluentValidation;
using FluentValidation.Validators;
using LibraryManagmentSystem.LogicLayer.Models;

namespace LibraryManagmentSystem.LogicLayer.Validators;

public class ValidatorForCreateModuleModel:AbstractValidator<CreateModuleModel>
{
   public ValidatorForCreateModuleModel() { }
}
