using CompanyTest;
using CompanyTest.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyTest.Controllers
{
    public class STUDENTController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public STUDENTController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult studentPostData()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult studentPostData(STUDENT student, IFormFile IMAGEPATH)
        {
            if (!ModelState.IsValid)
            {

                string uniqueFileName = string.Empty;
                if (IMAGEPATH != null && IMAGEPATH.Length > 0)
                {
                    string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + IMAGEPATH.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        IMAGEPATH.CopyTo(fileStream);
                    }

                    student.IMAGEPATH = uniqueFileName;

                }

                _context.Add(student);
                _context.SaveChanges();
                return RedirectToAction("ListStudents", "STUDENT");
            }

            return View(student);
        }



        [HttpGet]
        public IActionResult ListStudents(string searchTerm)
        {

            var students = _context.STUDENT.AsQueryable();


            if (!string.IsNullOrEmpty(searchTerm))
            {
                students = students.Where(s => s.NAME.Contains(searchTerm));
            }

            var groupedStudents = students.OrderBy(s => s.CLASS).ToList();

            var viewModel = new StudentFilterViewModel
            {
                SearchTerm = searchTerm,
                Students = groupedStudents
            };

            return View(viewModel);
        }


        [HttpGet]
        public IActionResult teacherPostData()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult teacherPostData(TEACHER teacher, IFormFile image)
        {
            string uniqueFileName = string.Empty;

            if (image != null && image.Length > 0)
            {

                string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "teacherimg");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }

                teacher.IMAGE = uniqueFileName;
            }

            _context.Add(teacher);
            _context.SaveChanges();
            return RedirectToAction("ListStudents", "STUDENT");
        }


        [HttpGet]
        public IActionResult subjectsPostData()
        {
            return View();
        }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult subjectsPostData(SUBJECTS subjects)
            {
            
                _context.Add(subjects);
                _context.SaveChanges();
                return View();

            }


        [HttpGet]
        public async Task<IActionResult> getData() 
        {
            var subjects = await _context.SUBJECTS
                .Include(s => s.TEACHER) 
                .ToListAsync(); 

            return View(subjects); 
        }


    }
}
