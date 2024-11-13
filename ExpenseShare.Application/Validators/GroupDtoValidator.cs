using ExpenseShare.Application.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShare.Application.Validators
{
    public class GroupDtoValidator : AbstractValidator<GroupCreateDto>
    {
        public GroupDtoValidator()
        {
            RuleFor(group => group.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(3).WithMessage("Name must be at least 3 characters long.")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");

            RuleFor(group => group.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MinimumLength(3).WithMessage("Description must be at least 3 characters long.");

            RuleFor(group => group.MemberEmails)
                .NotEmpty().WithMessage("MemberEmails must contain at least one member.")
                .Must(emails => emails.Distinct().Count() == emails.Count()).WithMessage("MemberEmails must not contain duplicate values.")
                .Must(emails => emails.Count() <= 10).WithMessage("MemberEmails must not exceed 10 values.");
        }
    }
}
