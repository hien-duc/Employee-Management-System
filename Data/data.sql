-- Insert Roles
INSERT INTO dbo.Roles (RoleName, Status, CreatedDate)
VALUES
    ('Admin', 1, GETDATE()),
    ('HRManager', 1, GETDATE()),
    ('Viewer', 1, GETDATE());

-- Insert Departments
INSERT INTO dbo.Departments (DepartmentCode, DepartmentName, Description, Status, CreatedDate)
VALUES
    ('IT', 'Information Technology', 'IT Department', 1, GETDATE()),
    ('HR', 'Human Resources', 'HR Department', 1, GETDATE()),
    ('FIN', 'Finance', 'Finance Department', 1, GETDATE());

-- Insert Employees
INSERT INTO dbo.Employees (EmployeeCode, FullName, Email, Phone, DepartmentId, Position, Salary, HireDate, Status, ProfileImage)
VALUES
    ('EMP001', 'John Doe', 'john.doe@example.com', '123-456-7890', (SELECT Id FROM dbo.Departments WHERE DepartmentCode = 'IT'), 'Software Developer', 75000.00, '2023-01-01', 1, 'john.jpg'),
    ('EMP002', 'Jane Smith', 'jane.smith@example.com', '234-567-8901', (SELECT Id FROM dbo.Departments WHERE DepartmentCode = 'HR'), 'HR Specialist', 65000.00, '2023-01-01', 1, 'jane.jpg'),
    ('EMP003', 'Robert Johnson', 'robert.johnson@example.com', '345-678-9012', (SELECT Id FROM dbo.Departments WHERE DepartmentCode = 'FIN'), 'Financial Analyst', 70000.00, '2023-01-01', 1, 'robert.jpg'),
    ('EMP004', 'Emily Davis', 'emily.davis@example.com', '456-789-0123', (SELECT Id FROM dbo.Departments WHERE DepartmentCode = 'IT'), 'System Administrator', 72000.00, '2023-01-01', 1, 'emily.jpg'),
    ('EMP005', 'Michael Wilson', 'michael.wilson@example.com', '567-890-1234', (SELECT Id FROM dbo.Departments WHERE DepartmentCode = 'FIN'), 'Accountant', 68000.00, '2023-01-01', 1, 'michael.jpg');

-- Additional Employees
-- Insert Employees (Additional 20 Rows)
INSERT INTO dbo.Employees (EmployeeCode, FullName, Email, Phone, DepartmentId, Position, Salary, HireDate, Status, ProfileImage)
VALUES
    ('EMP006', 'Sophia White', 'sophia.white@example.com', '678-901-2345', (SELECT Id FROM dbo.Departments WHERE DepartmentCode = 'IT'), 'Frontend Developer', 74000.00, '2023-02-01', 1, 'sophia.jpg'),
    ('EMP007', 'Liam Brown', 'liam.brown@example.com', '789-012-3456', (SELECT Id FROM dbo.Departments WHERE DepartmentCode = 'HR'), 'HR Coordinator', 63000.00, '2023-02-01', 1, 'liam.jpg'),
    ('EMP008', 'Olivia Taylor', 'olivia.taylor@example.com', '890-123-4567', (SELECT Id FROM dbo.Departments WHERE DepartmentCode = 'FIN'), 'Financial Planner', 75000.00, '2023-02-01', 1, 'olivia.jpg'),
    ('EMP009', 'Noah Lee', 'noah.lee@example.com', '901-234-5678', (SELECT Id FROM dbo.Departments WHERE DepartmentCode = 'IT'), 'DevOps Engineer', 77000.00, '2023-03-01', 1, 'noah.jpg'),
    ('EMP010', 'Emma Clark', 'emma.clark@example.com', '012-345-6789', (SELECT Id FROM dbo.Departments WHERE DepartmentCode = 'HR'), 'Recruitment Specialist', 69000.00, '2023-03-01', 1, 'emma.jpg'),
    ('EMP011', 'Mason Harris', 'mason.harris@example.com', '123-456-7891', (SELECT Id FROM dbo.Departments WHERE DepartmentCode = 'FIN'), 'Financial Consultant', 80000.00, '2023-03-01', 1, 'mason.jpg'),
    ('EMP012', 'Ava Walker', 'ava.walker@example.com', '234-567-8902', (SELECT Id FROM dbo.Departments WHERE DepartmentCode = 'IT'), 'Web Developer', 71000.00, '2023-04-01', 1, 'ava.jpg'),
    ('EMP013', 'Ethan Lewis', 'ethan.lewis@example.com', '345-678-9013', (SELECT Id FROM dbo.Departments WHERE DepartmentCode = 'HR'), 'Employee Relations Specialist', 65000.00, '2023-04-01', 1, 'ethan.jpg'),
    ('EMP014', 'Isabella Young', 'isabella.young@example.com', '456-789-0124', (SELECT Id FROM dbo.Departments WHERE DepartmentCode = 'FIN'), 'Senior Accountant', 79000.00, '2023-04-01', 1, 'isabella.jpg'),
    ('EMP015', 'James King', 'james.king@example.com', '567-890-1235', (SELECT Id FROM dbo.Departments WHERE DepartmentCode = 'IT'), 'IT Support Specialist', 69000.00, '2023-05-01', 1, 'james.jpg'),
    ('EMP016', 'Mia Scott', 'mia.scott@example.com', '678-901-2346', (SELECT Id FROM dbo.Departments WHERE DepartmentCode = 'HR'), 'HR Generalist', 67000.00, '2023-05-01', 1, 'mia.jpg'),
    ('EMP017', 'Benjamin Adams', 'benjamin.adams@example.com', '789-012-3457', (SELECT Id FROM dbo.Departments WHERE DepartmentCode = 'FIN'), 'Audit Associate', 71000.00, '2023-05-01', 1, 'benjamin.jpg'),
    ('EMP018', 'Charlotte Nelson', 'charlotte.nelson@example.com', '890-123-4568', (SELECT Id FROM dbo.Departments WHERE DepartmentCode = 'IT'), 'Network Administrator', 73000.00, '2023-06-01', 1, 'charlotte.jpg'),
    ('EMP019', 'Amelia Carter', 'amelia.carter@example.com', '901-234-5679', (SELECT Id FROM dbo.Departments WHERE DepartmentCode = 'HR'), 'Compensation Analyst', 69000.00, '2023-06-01', 1, 'amelia.jpg'),
    ('EMP020', 'William Mitchell', 'william.mitchell@example.com', '012-345-6780', (SELECT Id FROM dbo.Departments WHERE DepartmentCode = 'FIN'), 'Tax Specialist', 72000.00, '2023-06-01', 1, 'william.jpg'),
    ('EMP021', 'Lucas Perez', 'lucas.perez@example.com', '123-456-7892', (SELECT Id FROM dbo.Departments WHERE DepartmentCode = 'IT'), 'Backend Developer', 78000.00, '2023-07-01', 1, 'lucas.jpg'),
    ('EMP022', 'Grace Evans', 'grace.evans@example.com', '234-567-8903', (SELECT Id FROM dbo.Departments WHERE DepartmentCode = 'HR'), 'Training Coordinator', 64000.00, '2023-07-01', 1, 'grace.jpg'),
    ('EMP023', 'Henry Robinson', 'henry.robinson@example.com', '345-678-9014', (SELECT Id FROM dbo.Departments WHERE DepartmentCode = 'FIN'), 'Financial Manager', 85000.00, '2023-07-01', 1, 'henry.jpg');


-- Insert Users
INSERT INTO dbo.Users (Username, Password, Email, FullName, RoleID, Status, CreatedDate)
VALUES
    ('admin', 'admin123', 'admin@example.com', 'System Administrator', (SELECT Id FROM dbo.Roles WHERE RoleName = 'Admin'), 1, GETDATE()),
    ('hrmanager', 'hr123', 'hr@example.com', 'HR Manager', (SELECT Id FROM dbo.Roles WHERE RoleName = 'HRManager'), 1, GETDATE()),
    ('viewer1', 'viewer123', 'viewer1@example.com', 'Viewer One', (SELECT Id FROM dbo.Roles WHERE RoleName = 'Viewer'), 1, GETDATE()),
    ('viewer2', 'viewer456', 'viewer2@example.com', 'Viewer Two', (SELECT Id FROM dbo.Roles WHERE RoleName = 'Viewer'), 1, GETDATE());

-- Insert Carousels
INSERT INTO dbo.Carousels (Title, Description, ImagePath, IsActive, Status, CreatedDate)
VALUES
    ('Welcome to Employee Management System', 'Efficiently manage your organization workforce', '/carousel/banner1.png', 1, 1, GETDATE()),
    ('Streamline HR Processes', 'Simplify employee onboarding, management, and reporting', '/carousel/banner2.png', 1, 1, GETDATE()),
    ('Data-Driven Decisions', 'Make informed decisions with comprehensive employee analytics', '/carousel/banner3.png', 1, 1, GETDATE());
