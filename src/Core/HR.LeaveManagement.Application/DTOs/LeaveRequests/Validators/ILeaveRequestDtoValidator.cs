using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequests.Validators;

public class ILeaveRequestDtoValidator : AbstractValidator<ILeaveRequestDto>{
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public ILeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(p => p.StartDate)
            .LessThan(p => p.EndDate).WithMessage("{ProperyName} should be less than {ComparisonValue}");

            RuleFor(p => p.EndDate)
            .GreaterThan(p => p.StartDate).WithMessage("{ProperyName} should be greater than {ComparisonValue}");

            RuleFor(p => p.LeaveTypeId)
            .GreaterThan(0)
            .MustAsync(async (id,token) =>{
                var leaveTypeExists = await _leaveTypeRepository.Exists(id);
                return !leaveTypeExists;

            }).WithMessage("{PropertyName} doesn't exist");
        }

    }
