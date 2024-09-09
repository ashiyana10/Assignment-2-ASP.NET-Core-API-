using Assignment_2__ASP.NET_Core_API_.Data;
using Assignment_2__ASP.NET_Core_API_.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_2__ASP.NET_Core_API_.Services
{
    public class DepartmentService : IDepartmentService
    {
        public readonly DataContext dataContext;
        public readonly Department[] departmentData;
        public DepartmentService(DataContext context) {
            this.dataContext = context;
           this.departmentData = this.dataContext.Department.ToArray();
        }

        public async Task<Department[]> GetDepartmentData()
        {
           return await this.dataContext.Department.ToArrayAsync();
        }

        public async Task<bool> AddDepartmentData(Department department)
        {
            var isAvailable = departmentData.FirstOrDefault((item) => item.DepartmentName?.ToLower() == department.DepartmentName?.ToLower());
            if (isAvailable == null)
            {
               await dataContext.Department.AddAsync(department);
               await dataContext.SaveChangesAsync();
               return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateDepartmentData(int id,string departmentName) {
            var data = departmentData.FirstOrDefault((item) => item.Id == id);
            if(data == null)
            {
                return false;
            }
            else
            {
                data.DepartmentName = departmentName;
                dataContext.Department.Update(data);
                await dataContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> DeleteDepartmentData(int id)
        {
            var data = departmentData.FirstOrDefault((item) => item.Id == id);
            if (data == null) { 
                return false;
            }
            else
            {
                dataContext.Remove(data);
                await dataContext.SaveChangesAsync();
                return true;
            }
        }
    }
}
