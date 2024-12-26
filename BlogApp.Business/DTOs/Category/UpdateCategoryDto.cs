using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.Category
{
    public class UpdateCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateCategoryValidatorDto : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryValidatorDto()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();
            RuleFor(x=>x.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(20);
        }
    }
}
