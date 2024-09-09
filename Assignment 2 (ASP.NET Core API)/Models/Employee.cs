using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_2__ASP.NET_Core_API_.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string? Name { get; set; }
        [Range(21,100)]
        public int Age { get; set; }

        // Foreign Key property
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public int salary { get; set; }
    }

    public interface IEmployeeService
    {
        Employee[] GetEmployeeData();
        Task<bool> AddEmployeeData(EmployeeDTO employee);
        Task<bool> DeleteEmployeeData(int Id);
        Task<bool> UpdateEmployeeData(int Id, EmployeeDTO employee);

    }

    public class EmployeeDTO
    {
        [Required]
        [MaxLength(30)]
        public string? Name { get; set; }
        [Range(21, 100)]
        public int Age { get; set; }
        public int DepartmentId { get; set; }
        public int salary { get; set; }
    }
}
