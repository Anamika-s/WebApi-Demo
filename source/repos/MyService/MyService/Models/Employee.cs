using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyService.Models
{
    public class Employee
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Dept { get; set; }
        public int Salary { get; set; }
    }
    public class EmployeeDbContext : DbContext
    {
        public  EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options) { }
        public DbSet<Employee> employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().
                HasData(new Employee
                {
                    Id = 1,
                    Name = "Ajay",
                    Dept = "HR",
                    Salary = 90000
                }, new Employee
                {
                    Id = 2,
                    Name = "Deepak",
                    Dept = "Accts",
                    Salary = 98000
                }
                );


        }


    }

}
