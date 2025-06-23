using Employee_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Employee_Management_System.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Ensure database is created
            context.Database.EnsureCreated();

            // Seed Roles if they don't exist
            if (!context.Roles.Any())
            {
                var roles = new Role[]
                {
                    new Role { RoleName = "Admin" },
                    new Role { RoleName = "HRManager" },
                    new Role { RoleName = "Viewer" }
                };

                context.Roles.AddRange(roles);
                context.SaveChanges();
            }

            // Seed Departments if they don't exist
            if (!context.Departments.Any())
            {
                var departments = new Department[]
                {
                    new Department { DepartmentCode = "IT", DepartmentName = "Information Technology", Description = "IT Department" },
                    new Department { DepartmentCode = "HR", DepartmentName = "Human Resources", Description = "HR Department" },
                    new Department { DepartmentCode = "FIN", DepartmentName = "Finance", Description = "Finance Department" }
                };

                context.Departments.AddRange(departments);
                context.SaveChanges();
            }

            // Seed Employees if they don't exist
            if (!context.Employees.Any())
            {
                var itDept = context.Departments.FirstOrDefault(d => d.DepartmentCode == "IT");
                var hrDept = context.Departments.FirstOrDefault(d => d.DepartmentCode == "HR");
                var finDept = context.Departments.FirstOrDefault(d => d.DepartmentCode == "FIN");

                var employees = new Employee[]
                {
                    new Employee
                    {
                        EmployeeCode = "EMP001",
                        FullName = "John Doe",
                        Email = "john.doe@example.com",
                        Phone = "123-456-7890",
                        DepartmentId = itDept.Id,
                        Position = "Software Developer",
                        Salary = 75000.00M,
                        ProfileImage = "/images/profiles/john.jpg"
                    },
                    new Employee
                    {
                        EmployeeCode = "EMP002",
                        FullName = "Jane Smith",
                        Email = "jane.smith@example.com",
                        Phone = "234-567-8901",
                        DepartmentId = hrDept.Id,
                        Position = "HR Specialist",
                        Salary = 65000.00M,
                        ProfileImage = "/images/profiles/jane.jpg"
                    },
                    new Employee
                    {
                        EmployeeCode = "EMP003",
                        FullName = "Robert Johnson",
                        Email = "robert.johnson@example.com",
                        Phone = "345-678-9012",
                        DepartmentId = finDept.Id,
                        Position = "Financial Analyst",
                        Salary = 70000.00M,
                        ProfileImage = "/images/profiles/robert.jpg"
                    },
                    new Employee
                    {
                        EmployeeCode = "EMP004",
                        FullName = "Emily Davis",
                        Email = "emily.davis@example.com",
                        Phone = "456-789-0123",
                        DepartmentId = itDept.Id,
                        Position = "System Administrator",
                        Salary = 72000.00M,
                        ProfileImage = "/images/profiles/emily.jpg"
                    },
                    new Employee
                    {
                        EmployeeCode = "EMP005",
                        FullName = "Michael Wilson",
                        Email = "michael.wilson@example.com",
                        Phone = "567-890-1234",
                        DepartmentId = finDept.Id,
                        Position = "Accountant",
                        Salary = 68000.00M,
                        ProfileImage = "/images/profiles/michael.jpg"
                    }
                };

                context.Employees.AddRange(employees);
                context.SaveChanges();
            }

            // Seed Users if they don't exist
            if (!context.Users.Any())
            {
                var adminRole = context.Roles.FirstOrDefault(r => r.RoleName == "Admin");
                var hrManagerRole = context.Roles.FirstOrDefault(r => r.RoleName == "HRManager");
                var viewerRole = context.Roles.FirstOrDefault(r => r.RoleName == "Viewer");

                var users = new User[]
                {
                    new User
                    {
                        Username = "admin",
                        Password = "admin123", // Plain text password
                        Email = "admin@example.com",
                        FullName = "System Administrator",
                        RoleID = adminRole.Id
                    },
                    new User
                    {
                        Username = "hrmanager",
                        Password = "hr123", // Plain text password
                        Email = "hr@example.com",
                        FullName = "HR Manager",
                        RoleID = hrManagerRole.Id
                    },
                    new User
                    {
                        Username = "viewer1",
                        Password = "viewer123", // Plain text password
                        Email = "viewer1@example.com",
                        FullName = "Viewer One",
                        RoleID = viewerRole.Id
                    },
                    new User
                    {
                        Username = "viewer2",
                        Password = "viewer456", // Plain text password
                        Email = "viewer2@example.com",
                        FullName = "Viewer Two",
                        RoleID = viewerRole.Id
                    }
                };

                context.Users.AddRange(users);
                context.SaveChanges();
            }

            // Seed Carousels if they don't exist
            if (!context.Carousels.Any())
            {
                var carousels = new Carousel[]
                {
                    new Carousel
                    {
                        Title = "Welcome to Employee Management System",
                        Description = "Efficiently manage your organization's workforce",
                        ImagePath = "/carousel/banner1.png",
                        IsActive = true
                    },
                    new Carousel
                    {
                        Title = "Streamline HR Processes",
                        Description = "Simplify employee onboarding, management, and reporting",
                        ImagePath = "/carousel/banner2.png",
                        IsActive = true
                    },
                    new Carousel
                    {
                        Title = "Data-Driven Decisions",
                        Description = "Make informed decisions with comprehensive employee analytics",
                        ImagePath = "/carousel/banner3.png",
                        IsActive = true
                    }
                };

                context.Carousels.AddRange(carousels);
                context.SaveChanges();
            }
        }
    }
}