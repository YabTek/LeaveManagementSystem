namespace HR.LeaveManagement.Application.DTOs.LeaveRequests;

public interface ILeaveRequestDto{
        public DateTime EndDate { get; }
        public DateTime StartDate { get; }
        public  int LeaveTypeId { get; }
    }