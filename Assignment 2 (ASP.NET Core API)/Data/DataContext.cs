using Assignment_2__ASP.NET_Core_API_.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_2__ASP.NET_Core_API_.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options) : base(options) 
        { 
        }
       public DbSet<Employee> Employee { get; set; }
       public DbSet<Department> Department { get; set; }
    }
}
