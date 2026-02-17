using CRM.Application.Activities.Commands;
using CRM.Application.Activities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Activities.Validators
{
    public class CreateActivityValidator : AbstractValidator<CreateActivity.Command>
    {
        public CreateActivityValidator()
        {
            RuleFor(x => x.ActivityDto.Type).NotEmpty().WithMessage("Type is required");
            RuleFor(x => x.ActivityDto.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.ActivityDto.Priority).NotEmpty().WithMessage("Priority is required");
            RuleFor(x => x.ActivityDto.DueDateTime).NotEmpty().WithMessage("DueDateTime is required");
            RuleFor(x => x.ActivityDto.Note).MaximumLength(500).WithMessage("MaximumLength of field Note need to be 500");
        }
    }
}
