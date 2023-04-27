using HR.LeaveManagement.Application.DTOs.LeaveAllocations;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;

public class CreateLeaveAllocationCommand : IRequest<int>{
    public CreateLeaveAllocationDto LeaveAllocationDto { get; set; }
}