using Microsoft.EntityFrameworkCore;
using PayrollService.Data;
using PayrollService.Models;
using PayrollService.Repositories.Interface;

namespace PayrollService.Repositories.Services
{
    public class SQLEmployee : IEmployee
    {
        private readonly EmployeeDbContext employeeDbContext;

        public SQLEmployee(EmployeeDbContext employeeDbContext)
        {
            this.employeeDbContext = employeeDbContext;
        }
        public async Task<EmployeeModel> CreateAsync(EmployeeModel model)
        {
            await employeeDbContext.Employees.AddAsync(model);
            await employeeDbContext.SaveChangesAsync();
            return model;
        }

        public async Task<EmployeeModel?> DeleteAsync(int id)
        {
            var isexists = await employeeDbContext.Employees.FirstOrDefaultAsync(x => x.ID == id);

            if (isexists == null)
            {
                return null;
            }
            employeeDbContext.Employees.Remove(isexists);
            employeeDbContext.SaveChanges();
            return isexists;
        }

        public async Task<List<EmployeeModel>> GetAllAsync()
        {
            return await employeeDbContext.Employees.ToListAsync();
        }

        public async Task<EmployeeModel?> GetByIdAsync(int id)
        {
           return await employeeDbContext.Employees.SingleOrDefaultAsync(e=>e.ID == id);
        }

        public async Task<EmployeeModel> UpdateAsync(int id, EmployeeModel model)
        {
            var isExists= await employeeDbContext.Employees.SingleOrDefaultAsync(e => e.ID == id);

            if (isExists == null) {
                return null;
            }
            isExists.EmployeeName = model.EmployeeName;
            isExists.Designation    = model.Designation;
            employeeDbContext.SaveChanges();
            return model;
        }
    }
}
