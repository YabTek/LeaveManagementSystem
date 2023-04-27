using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveRequest>, ILeaveAllocationRepository{
        private readonly LeaveManagementDbContext _dbContext;
        public LeaveAllocationRepository(LeaveManagementDbContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }

    public Task<LeaveAllocation> Add(LeaveAllocation entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(LeaveAllocation entity)
    {
        throw new NotImplementedException();
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            var leaveAllocations = await _dbContext.LeaveAllocations
            .Include(q => q.LeaveType).ToListAsync();

            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var leaveAllocation = await _dbContext.LeaveAllocations
            .Include(q => q.LeaveType).FirstOrDefaultAsync(q => q.Id == id);

            return leaveAllocation;
        }

    public Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
    {
        throw new NotImplementedException();
    }

    public Task Update(LeaveAllocation entity)
    {
        throw new NotImplementedException();
    }

    Task<LeaveAllocation> IGenericRepository<LeaveAllocation>.Get(int id)
    {
        throw new NotImplementedException();
    }

    Task<IReadOnlyList<LeaveAllocation>> IGenericRepository<LeaveAllocation>.GetAll()
    {
        throw new NotImplementedException();
    }
}
