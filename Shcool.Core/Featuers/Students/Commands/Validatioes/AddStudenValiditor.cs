using FluentValidation;
using Shcool.Core.Featuers.Students.Commands.Models;

namespace Shcool.Core.Featuers.Students.Commands.Validatioes
{
    internal class AddStudenValiditor : AbstractValidator<AddStudenCommand>
    {
        public int MyProperty { get; set; }
    }
}
