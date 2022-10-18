using EmployeeManagmentWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EmployeeManagmentWeb.DataContext
{
    public class ApplicationDbContext : IdentityDbContext <ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        //public DbSet<Course> Courses { get; set; }
        //public DbSet<ViewModelNew.Models.StudentCourse> StudentCourse { get; set; }
    }
}
