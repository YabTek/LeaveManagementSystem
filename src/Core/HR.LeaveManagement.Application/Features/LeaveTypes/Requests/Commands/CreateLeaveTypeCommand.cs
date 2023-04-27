using HR.LeaveManagement.Application.DTOs.LeaveTypes;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;

public class CreateLeaveTypeCommand : IRequest<int>{
    public LeaveTypeDto LeaveTypeDto { get; set; }

}