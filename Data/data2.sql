-- Roles
INSERT INTO Roles (RoleName) VALUES 
('Admin'),
('HRManager'),
('Viewer'),
('User');

-- Departments
INSERT INTO Departments (DepartmentCode, DepartmentName, Description) VALUES 
('IT', 'Information Technology', 'IT Department'),
('HR', 'Human Resources', 'HR Department'),
('FIN', 'Finance', 'Finance Department');

-- Employees
-- Assuming department IDs: IT = 1, HR = 2, FIN = 3
INSERT INTO Employees (EmployeeCode, FullName, Email, Phone, DepartmentId, Position, Salary, ProfileImage) VALUES
('EMP001', 'John Doe', 'john.doe@example.com', '123-456-7890', 1, 'Software Developer', 75000.00, '/images/profiles/john.jpg'),
('EMP002', 'Jane Smith', 'jane.smith@example.com', '234-567-8901', 2, 'HR Specialist', 65000.00, '/images/profiles/jane.jpg'),
('EMP003', 'Robert Johnson', 'robert.johnson@example.com', '345-678-9012', 3, 'Financial Analyst', 70000.00, '/images/profiles/robert.jpg'),
('EMP004', 'Emily Davis', 'emily.davis@example.com', '456-789-0123', 1, 'System Administrator', 72000.00, '/images/profiles/emily.jpg'),
('EMP005', 'Michael Wilson', 'michael.wilson@example.com', '567-890-1234', 3, 'Accountant', 68000.00, '/images/profiles/michael.jpg');

-- Users
-- Assuming role IDs:
-- Admin = 1, HRManager = 2, Viewer = 3, User = 4
INSERT INTO Users (Username, Password, Email, FullName, RoleID) VALUES
('admin', 'admin123', 'admin@example.com', 'System Administrator', 1),
('hrmanager', 'hr123', 'hr@example.com', 'HR Manager', 2),
('viewer1', 'viewer123', 'viewer1@example.com', 'Viewer One', 3),
('viewer2', 'viewer456', 'viewer2@example.com', 'Viewer Two', 3),
('user1', 'user123', 'user1@example.com', 'User One', 4),
('user2', 'user456', 'user2@example.com', 'User Two', 4);

-- Carousels
INSERT INTO Carousels (Title, Description, ImagePath, IsActive) VALUES
('Welcome to Employee Management System', 'Efficiently manage your organization''s workforce', '/carousel/banner1.png', 1),
('Streamline HR Processes', 'Simplify employee onboarding, management, and reporting', '/carousel/banner2.png', 1),
('Data-Driven Decisions', 'Make informed decisions with comprehensive employee analytics', '/carousel/banner3.png', 1);
