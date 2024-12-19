using PayrollService.Models;

namespace PayrollService.Repositories.Interface
{
    public interface IEmployee
    {
        Task<List<EmployeeModel>> GetAllAsync();

        Task<EmployeeModel?> GetByIdAsync(int id);

        Task<EmployeeModel> CreateAsync(EmployeeModel model);

        Task<EmployeeModel> UpdateAsync(int id, EmployeeModel model);

        Task<EmployeeModel?> DeleteAsync(int id);
    }
}
