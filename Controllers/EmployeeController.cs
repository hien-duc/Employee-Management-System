using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Employee_Management_System.Data;
using Employee_Management_System.Models;
using Employee_Management_System.Models.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.IO;

namespace Employee_Management_System.Controllers
{
    // [Authorize] // Requires authentication
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public EmployeeController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Employee
        public async Task<IActionResult> Index(string searchString, int? departmentId, int page = 1)
        {
            // Store filter values in ViewData for form persistence
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentDepartment"] = departmentId;
            
            // Prepare department dropdown
            ViewData["DepartmentId"] = new SelectList(_context.Departments.Where(d => d.Status == 1), "Id", "DepartmentName");
            
            // Start with all employees
            var employeesQuery = _context.Employees
                .Include(e => e.Department)
                .AsQueryable();
                
            // Apply name search filter if provided
            if (!string.IsNullOrEmpty(searchString))
            {
                employeesQuery = employeesQuery.Where(e => e.FullName.Contains(searchString));
            }
            
            // Apply department filter if provided
            if (departmentId.HasValue)
            {
                employeesQuery = employeesQuery.Where(e => e.DepartmentId == departmentId.Value);
            }
            
            // Pagination settings
            int pageSize = 10;
            int totalItems = await employeesQuery.CountAsync();
            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            
            page = Math.Max(1, Math.Min(page, Math.Max(1, totalPages)));
            
            // Get the products for the current page
            var employees = await employeesQuery
                .OrderBy(p => p.FullName)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            
            // Map to view models
            var viewModels = employees.Select(e => new EmployeeViewModel
            {
                Id = e.Id,
                EmployeeCode = e.EmployeeCode,
                FullName = e.FullName,
                Email = e.Email,
                Phone = e.Phone ?? string.Empty,
                DepartmentId = e.DepartmentId,
                DepartmentName = e.Department?.DepartmentName ?? string.Empty,
                Position = e.Position ?? string.Empty,
                Salary = e.Salary,
                HireDate = e.HireDate,
                Status = e.Status == 1,
                ProfileImage = e.ProfileImage
            }).ToList();
            
            // Set pagination data for the view
            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = totalPages;
            
            return View(viewModels);
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Department)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (employee == null)
            {
                return NotFound();
            }
            
            var viewModel = new EmployeeViewModel
            {
                Id = employee.Id,
                EmployeeCode = employee.EmployeeCode,
                FullName = employee.FullName,
                Email = employee.Email,
                Phone = employee.Phone ?? string.Empty,
                DepartmentId = employee.DepartmentId,
                DepartmentName = employee.Department?.DepartmentName ?? string.Empty,
                Position = employee.Position ?? string.Empty,
                Salary = employee.Salary,
                HireDate = employee.HireDate,
                Status = employee.Status == 1,
                ProfileImage = employee.ProfileImage
            };

            return View(viewModel);
        }

        // GET: Employee/Create
        [Authorize(Roles = "Admin,HRManager")] // Only Admin and HRManager can create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "DepartmentName");
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,HRManager")]
        public async Task<IActionResult> Create(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if EmployeeCode is unique
                if (await _context.Employees.AnyAsync(e => e.EmployeeCode == model.EmployeeCode))
                {
                    ModelState.AddModelError("EmployeeCode", "Employee Code must be unique.");
                    ViewData["DepartmentId"] = new SelectList(_context.Departments.Where(d => d.Status == 1), "Id", "DepartmentName", model.DepartmentId);
                    return View(model);
                }

                // Check if Email is unique
                if (await _context.Employees.AnyAsync(e => e.Email == model.Email))
                {
                    ModelState.AddModelError("Email", "Email must be unique.");
                    ViewData["DepartmentId"] = new SelectList(_context.Departments.Where(d => d.Status == 1), "Id", "DepartmentName", model.DepartmentId);
                    return View(model);
                }

                var employee = new Employee
                {
                    EmployeeCode = model.EmployeeCode,
                    FullName = model.FullName,
                    Email = model.Email,
                    Phone = model.Phone,
                    DepartmentId = model.DepartmentId,
                    Position = model.Position,
                    Salary = model.Salary,
                    HireDate = model.HireDate,
                    Status = model.Status ? 1 : 0,
                    ProfileImage = "", // Will be updated if file is uploaded
                };

                // Handle profile image upload
                if (model.ProfileImageFile != null)
                {
                    string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images", "profiles");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImageFile.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Ensure directory exists
                    Directory.CreateDirectory(uploadsFolder);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.ProfileImageFile.CopyToAsync(fileStream);
                    }

                    employee.ProfileImage = uniqueFileName;
                }

                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["DepartmentId"] = new SelectList(_context.Departments.Where(d => d.Status == 1), "Id", "DepartmentName", model.DepartmentId);
            return View(model);
        }

        // GET: Employee/Edit/5
        [Authorize(Roles = "Admin,HRManager")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            var viewModel = new EmployeeViewModel
            {
                Id = employee.Id,
                EmployeeCode = employee.EmployeeCode,
                FullName = employee.FullName,
                Email = employee.Email,
                Phone = employee.Phone,
                DepartmentId = employee.DepartmentId,
                Position = employee.Position,
                Salary = employee.Salary,
                HireDate = employee.HireDate,
                Status = employee.Status == 1,
                ProfileImage = employee.ProfileImage
            };

            ViewData["DepartmentId"] = new SelectList(_context.Departments.Where(d => d.Status == 1), "Id", "DepartmentName", employee.DepartmentId);
            return View(viewModel);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,HRManager")]
        public async Task<IActionResult> Edit(int id, EmployeeViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Check if EmployeeCode is unique (excluding current employee)
                if (await _context.Employees.AnyAsync(e => e.EmployeeCode == model.EmployeeCode && e.Id != model.Id))
                {
                    ModelState.AddModelError("EmployeeCode", "Employee Code must be unique.");
                    ViewData["DepartmentId"] = new SelectList(_context.Departments.Where(d => d.Status == 1), "Id", "DepartmentName", model.DepartmentId);
                    return View(model);
                }

                // Check if Email is unique (excluding current employee)
                if (await _context.Employees.AnyAsync(e => e.Email == model.Email && e.Id != model.Id))
                {
                    ModelState.AddModelError("Email", "Email must be unique.");
                    ViewData["DepartmentId"] = new SelectList(_context.Departments.Where(d => d.Status == 1), "Id", "DepartmentName", model.DepartmentId);
                    return View(model);
                }

                try
                {
                    var employee = await _context.Employees.FindAsync(id);
                    if (employee == null)
                    {
                        return NotFound();
                    }

                    employee.FullName = model.FullName;
                    employee.Email = model.Email;
                    employee.Phone = model.Phone;
                    employee.DepartmentId = model.DepartmentId;
                    employee.Position = model.Position;
                    employee.Salary = model.Salary;
                    employee.HireDate = model.HireDate;
                    employee.Status = model.Status ? 1 : 0;

                    // Handle profile image upload
                    if (model.ProfileImageFile != null)
                    {
                        string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images", "profiles");
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImageFile.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        // Ensure directory exists
                        Directory.CreateDirectory(uploadsFolder);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await model.ProfileImageFile.CopyToAsync(fileStream);
                        }

                        // Delete old image if exists
                        if (!string.IsNullOrEmpty(employee.ProfileImage))
                        {
                            string oldImagePath = Path.Combine(uploadsFolder, employee.ProfileImage);
                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                            }
                        }

                        employee.ProfileImage = uniqueFileName;
                    }

                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["DepartmentId"] = new SelectList(_context.Departments.Where(d => d.Status == 1), "Id", "DepartmentName", model.DepartmentId);
            return View(model);
        }

        // GET: Employee/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Department)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            var viewModel = new EmployeeViewModel
            {
                Id = employee.Id,
                EmployeeCode = employee.EmployeeCode,
                FullName = employee.FullName,
                Email = employee.Email,
                Phone = employee.Phone,
                DepartmentId = employee.DepartmentId,
                DepartmentName = employee.Department.DepartmentName,
                Position = employee.Position,
                Salary = employee.Salary,
                HireDate = employee.HireDate,
                Status = employee.Status == 1,
                ProfileImage = employee.ProfileImage
            };

            return View(viewModel);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                // Delete profile image if exists
                if (!string.IsNullOrEmpty(employee.ProfileImage))
                {
                    string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images", "profiles");
                    string imagePath = Path.Combine(uploadsFolder, employee.ProfileImage);
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }

                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}