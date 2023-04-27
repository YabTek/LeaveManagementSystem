using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocations.Validators;

public class ILeaveAllocationDtoValidator : AbstractValidator<ILeaveAllocationDto>{
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public ILeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(p => p.NumberOfDays)
            .GreaterThan(0).WithMessage("{ProperyName} should be greater than {ComparisonValue}");
            RuleFor(p => p.Period)
            .GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("{ProperyName} should be after {ComparisonValue}");

            RuleFor(p => p.LeaveTypeId)
            .GreaterThan(0)
            .MustAsync(async (id,token) =>{
                var leaveTypeExists = await _leaveTypeRepository.Exists(id);
                return !leaveTypeExists;

            }).WithMessage("{PropertyName} doesn't exist");
        }

    }

