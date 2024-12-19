using System.ComponentModel.DataAnnotations;

namespace PayrollService.Models
{
    public class EmployeeModel
    {
        [Key]
        public int ID { get; set; }

        public string? EmployeeName { get; set; }

        public string? Designation { get; set; }
    }
}
