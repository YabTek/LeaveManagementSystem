using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequests.Validators;

public class UpdateLeaveRequestDtoValidator : AbstractValidator<UpdateLeaveRequestDto>{
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            Include(new ILeaveRequestDtoValidator(_leaveTypeRepository));
            RuleFor(p => p.Id)
        .NotNull().WithMessage("{PropertyName} is required");
        }



        

    }