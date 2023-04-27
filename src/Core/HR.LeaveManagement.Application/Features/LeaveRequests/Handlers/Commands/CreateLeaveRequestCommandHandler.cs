using AutoMapper;
using FluentValidation;
using HR.LeaveManagement.Application.Contracts;
using HR.LeaveManagement.Application.Contracts.Infrastructure;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.LeaveRequests.Validators;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Models;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands;

public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
{
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
       // private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;

    public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, 
    ILeaveTypeRepository leaveTypeRepository,
    //IEmailSender emailSender,
    IMapper mapper)
         {
        _leaveRequestRepository = leaveRequestRepository;
        _leaveTypeRepository = leaveTypeRepository;
        // _emailSender = emailSender;
        _mapper = mapper;
        
        }
    public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
      

        // var response = new BaseCommandResponse();
        // var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
        //  var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);

        //  if(!validationResult.IsValid){
        //     response.Success = false;
        //     response.Message = "Creation failed";
        //     response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        //      throw new Exception();
        //  }
         var leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDto);
         leaveRequest = await _leaveRequestRepository.Add(leaveRequest);

        //  response.Success = true;
        //  response.Message = "Creation successful.";
        //  response.Id  = leaveRequest.Id;

        //  var email = new Email{
        //     To = "employee@example.com",
        //     Body = $"your leave request for {request.LeaveRequestDto.StartDate:D} to {request.LeaveRequestDto.EndDate} has been submitted successfully",
        //     Subject = "Leave request submitted"
        //  };
        //  try{
        //     await _emailSender.SendEmail(email);
        //  }
        //  catch(Exception ex){

        //  }

         return leaveRequest.Id;

      
        
    }
}
