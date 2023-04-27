using FluentValidation;

namespace HR.LeaveManagement.Application.DTOs.LeaveTypes.Validators;

public class ILeaveTypeDtoValidator : AbstractValidator<ILeaveTypeDto>{
        public ILeaveTypeDtoValidator()
        {
            RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} should not be more than {ComparisonValue} characters");

            RuleFor(p => p.DefaultDays)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .GreaterThan(0)
            .LessThan(100);

        }

        
    }