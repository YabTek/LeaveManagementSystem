using System.ComponentModel.DataAnnotations;
using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.LeaveAllocations.Validators;
using HR.LeaveManagement.Domain;
using MediatR;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands;


public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;
    public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository,
    ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;

    }
    public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateLeaveAllocationDtoValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request.LeaveAllocationDto);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.ToString());
        }
        var leaveAllocation = _mapper.Map<LeaveAllocation>(request.LeaveAllocationDto);
        leaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation);

        return leaveAllocation.Id;



    }
}