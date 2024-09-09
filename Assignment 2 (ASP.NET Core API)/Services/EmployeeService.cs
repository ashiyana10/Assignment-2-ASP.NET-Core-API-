using Assignment_2__ASP.NET_Core_API_.Data;
using Assignment_2__ASP.NET_Core_API_.Models;
namespace Assignment_2__ASP.NET_Core_API_.Services
{
    public class EmployeeService:IEmployeeService
    {
        public readonly DataContext dataContext;
        private readonly Employee[] employeeData;
        public EmployeeService(DataContext context) {
            this.dataContext = context;
            employeeData = this.dataContext.Employee.ToArray();

        }
        public Employee[] GetEmployeeData() {
           return this.dataContext.Employee.ToArray();
        }

        public async Task<bool> AddEmployeeData(EmployeeDTO employee)
        {
            var isAvailable = employeeData.FirstOrDefault((item) => item.Name?.ToLower() == employee.Name?.ToLower());
            if (isAvailable == null)
            {
                var employeeData = new Employee
                {
                    Name = employee.Name,
                    Age = employee.Age,
                    DepartmentId = employee.DepartmentId,
                    salary = employee.salary
                };
                await dataContext.Employee.AddAsync(employeeData);
                await dataContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateEmployeeData(int id, EmployeeDTO employee)
        {
            var data = employeeData.FirstOrDefault((item) => item.Id == id);
            if (data == null)
            {
                return false;
            }
            else
            {
                data.Name = employee.Name;
                data.DepartmentId = employee.DepartmentId;
                data.Age = employee.Age;
                data.salary = employee.salary;
                dataContext.Employee.Update(data);
                await dataContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> DeleteEmployeeData(int id)
        {
            var data = employeeData.FirstOrDefault((item) => item.Id == id);
            if (data == null)
            {
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
