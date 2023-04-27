using HR.LeaveManagement.Application.DTOs.Common;
using HR.LeaveManagement.Application.DTOs.LeaveTypes;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocations;

public class LeaveAllocationDto : BaseDto,ILeaveAllocationDto{
        public int NumberOfDays { get; set; }
        public string EmployeeId { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }