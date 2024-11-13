using ExpenseShare.Application.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseShare.Application.Validators
{
    public class ExpenseDtoValidator : AbstractValidator<ExpenseDto>
    {
        public ExpenseDtoValidator()
        {
            RuleFor(expense => expense.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MinimumLength(3).WithMessage("Description must be at least 3 characters long.")
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

            RuleFor(expense => expense.Amount)
                .GreaterThan(0).WithMessage("Amount must be greater than zero.");

            RuleFor(expense => expense.GroupId)
                .NotEmpty().WithMessage("GroupId is required.");

            //RuleFor(expense => expense.PaidByMemberId)
            //    .NotEmpty().WithMessage("PaidByMemberId is required.");

            RuleFor(expense => expense.SplitAmongMemberIds)
                .NotEmpty().WithMessage("SplitAmongMemberIds must contain at least one member.")
                .Must(ids => ids.Distinct().Count() == ids.Count()).WithMessage("SplitAmongMemberIds must not contain duplicate values.");
        }
    }
}
