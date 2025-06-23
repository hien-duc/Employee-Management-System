# Employee Management System

## Overview
This is an ASP.NET Core MVC application for managing employees, departments, users, and roles. The system provides functionality for employee management, department organization, and user access control with role-based permissions.

## Features
- Employee Management: Add, edit, view, and delete employee records
- Department Management: Organize employees by departments
- User Management: Control access to the system with role-based permissions
- Carousel Display: Showcase important information on the home page

## Database Schema

### Employee
- Id (PK, int, auto-increment)
- EmployeeCode (nvarchar(10), unique)
- FullName (nvarchar(200))
- Email (nvarchar(100), unique)
- Phone (nvarchar(20))
- DepartmentId (FK, int)
- Position (nvarchar(100))
- Salary (decimal(12,2))
- HireDate (date, default: getdate())
- Status (int, default: 1)
- ProfileImage (nvarchar(255))

### Department
- Id (PK, int, auto-increment)
- DepartmentCode (nvarchar(10), unique)
- DepartmentName (nvarchar(100))
- Description (nvarchar(500))
- Status (int, default: 1)
- CreatedDate (date, default: getdate())

### User
- Id (PK, int, auto-increment)
- Username (nvarchar(50), unique)
- Password (nvarchar(255))
- Email (nvarchar(100))
- FullName (nvarchar(100))
- RoleId (FK, int)
- Status (int, default: 1)
- CreatedDate (date, default: getdate())

### Role
- Id (PK, int, auto-increment)
- RoleName (nvarchar(50)) — Admin, HRManager, Viewer
- Status (int, default: 1)
- CreatedDate (date, default: getdate())

### Carousel
- Id (PK, int, auto-increment)
- Title (nvarchar(MAX))
- Description (nvarchar(MAX))
- ImagePath (nvarchar(255))
- IsActive (bit, default: 1)
- Status (int, default: 0)
- CreatedDate (date, default: getdate())

## Setup
1. Clone the repository
2. Ensure you have .NET 8.0 SDK installed
3. Update the connection string in appsettings.json if needed
4. Run the application

## Sample Data
The application is pre-configured with sample data:
- 3 roles: Admin, HRManager, Viewer
- 3 departments: IT, HR, Finance
- 5 employees
- 4 users (1 Admin, 1 HRManager, 2 Viewers)
- 3 carousel banners

## Technologies Used
- ASP.NET Core 8.0 MVC
- Entity Framework Core
- SQL Server
- Bootstrap
- BCrypt.Net for password hashing