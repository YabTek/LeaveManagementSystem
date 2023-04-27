namespace HR.LeaveManagement.Application.DTOs.LeaveAllocations;

public interface ILeaveAllocationDto{
        
        public int NumberOfDays { get; }
        public int Period { get; }
        public  int LeaveTypeId { get; }
    }