using Microsoft.AspNetCore.Mvc;
using YourProjectName.Models;

namespace YourProjectName.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>
        {
            new Student { StudentId = 1, FirstName = "John", LastName = "Doe", EmailAddress = "john.doe@example.com" },
            new Student { StudentId = 2, FirstName = "Jane", LastName = "Smith", EmailAddress = "" }
        };

        public IActionResult Index()
        {
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                student.StudentId = students.Count + 1;
                students.Add(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = students.FirstOrDefault(s => s.StudentId == id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                var existingStudent = students.FirstOrDefault(s => s.StudentId == student.StudentId);
                if (existingStudent != null)
                    existingStudent.LastName = student.LastName;
                {
                    existingStudent.FirstName = student.FirstName;
                    existingStudent.EmailAddress = student.EmailAddress;
                    return RedirectToAction("Index");
                }
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.StudentId == id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = students.FirstOrDefault(s => s.StudentId == id);
            if (student != null)
            {
                students.Remove(student);
            }
            return RedirectToAction("Index");
        }
    }
}
