using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_2__ASP.NET_Core_API_.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? DepartmentName { get; set; }
    }
    public interface IDepartmentService
    {
        Task<Department[]> GetDepartmentData();
        Task<bool> AddDepartmentData(Department department);
        Task<bool> UpdateDepartmentData(int id,string departmentName);
        Task<bool> DeleteDepartmentData(int id);
    }

}
