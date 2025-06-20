using Microsoft.EntityFrameworkCore;

namespace Company_System.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Models.Department> Departments { get; set; }
        public DbSet<Models.Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.Employee>()
                .HasOne(e => e.department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DeptId);

            //seed tables
            modelBuilder.Entity<Models.Department>().HasData(
                new Models.Department { Id = 1, Name = "HR", Description = "Human Resources Department" },
                new Models.Department { Id = 2, Name = "IT", Description = "Information Technology Department" },
                new Models.Department { Id = 3, Name = "Finance", Description = "Finance Department" }
            );
            modelBuilder.Entity<Models.Employee>().HasData(
                new Models.Employee
                {
                    Id = 303011,
                    Name = "Ali Ahmed",
                    Email = "ali@company.com",
                    Password = "Ali12345",
                    PhoneNumber = "01012345678",
                    Salary = 8000.00m,
                    JoinDate = new DateTime(2023, 5, 1),
                    DeptId = 1
                },
                new Models.Employee
                {
                    Id = 101011,
                    Name = "Mona Said",
                    Email = "mona@company.com",
                    Password = "Mona@123",
                    PhoneNumber = "01123456789",
                    Salary = 9500.00m,
                    JoinDate = new DateTime(2022, 11, 10),
                    DeptId = 2
                },
                new Models.Employee
                {
                    Id = 123456,
                    Name = "Hassan Omar",
                    Email = "hassan@company.com",
                    Password = "Hassan789!",
                    PhoneNumber = "01234567890",
                    Salary = 11000.00m,
                    JoinDate = new DateTime(2024, 1, 15),
                    DeptId = 3
                },
                new Models.Employee
                {
                    Id = 8080,
                    Name = "Sara Youssef",
                    Email = "Sara@company.com",
                    Password = "Sara@1234",
                    PhoneNumber = "01345678901",
                    Salary = 9000.00m,
                    JoinDate = new DateTime(2023, 8, 20),
                    DeptId = 1
                }
                );
        }       
    }
}
