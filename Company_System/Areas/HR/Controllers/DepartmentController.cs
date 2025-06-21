using Company_System.Data;
using Microsoft.AspNetCore.Mvc;

namespace Company_System.Areas.HR.Controllers
{
    [Area("HR")]
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DepartmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var depts = _context.Departments.ToList();
            return View(depts);
        }

        [HttpPost]
        public IActionResult Delete(int deptId)
        {
            var department = _context.Departments.FirstOrDefault(d => d.Id == deptId);
            if (department != null)
            {
                _context.Departments.Remove(department);
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
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }

        public IActionResult Edit(int deptId)
        {
            var department = _context.Departments.FirstOrDefault(d => d.Id == deptId);
            if (department != null)
            {
                return View(department);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Edit(Models.Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Update(department);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }

        public IActionResult Details(int deptId)
        {
            var department = _context.Departments.FirstOrDefault(d => d.Id == deptId);
            if (department != null)
            {
                return View(department);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
