using Company_System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Company_System.Areas.HR.Controllers
{
    [Area("HR")]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? departmentId)
        {
            ViewBag.Departments = new SelectList(_context.Departments.ToList(), "Id", "Name");

            var employees = _context.Employees.Include(e => e.department).AsQueryable();
            if (departmentId.HasValue && departmentId > 0)
            {
                employees = employees.Where(e => e.DeptId == departmentId.Value);
            }

            return View(employees.ToList());
        }

        [HttpPost]
        public IActionResult Delete(int empId)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == empId);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(_context.Departments.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = new SelectList(_context.Departments.ToList(), "Id", "Name");
            return View(employee);
        }

        public IActionResult Edit(int empId)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == empId);
            if (employee == null)
            {
                return NotFound();
            }
            ViewBag.Departments = new SelectList(_context.Departments.ToList(), "Id", "Name");
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Models.Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Update(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = new SelectList(_context.Departments.ToList(), "Id", "Name");
            return View(employee);
        }

        public IActionResult Details(int empId)
        {
            var employee = _context.Employees.Include(e => e.department).FirstOrDefault(e => e.Id == empId);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
    }
}
