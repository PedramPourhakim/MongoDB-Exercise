using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDbApi.Models;
using MongoDbApi.Services;

namespace MongoDbApi.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService studentService;
        public StudentsController(IStudentService studentService)
        {
            this.studentService = studentService;
        }
        // GET: StudentsController
        public ActionResult<List<Student>> Get()
        {
            return studentService.Get();
        }

        // GET: StudentsController/Details/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(string id)
        {
            var student= studentService.Get(id);
            if (student == null)
            {
                return NotFound($"Student With Id ={id} not found");
            }
            return student;
        }

        // GET: StudentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentsController/Create
        [HttpPost]
        public ActionResult<Student> Post([FromBody] Student student)
        {
            studentService.Create(student);
            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }

        // GET: StudentsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Student student)
        {
            var existingStudent = studentService.Get(id);
            if (existingStudent == null)
            {
                return NotFound($"Student With Id ={id} Not Found !");
            }
            studentService.Update(id, student);
            return NoContent();
        }

        // POST: StudentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentsController/Delete/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var student = studentService.Get(id);
            if (student == null)
            {
                return NotFound($"Student With Id={id} not found");
            }
            studentService.Remove(student.Id);
            return Ok($"Student With Id ={id} deleted");
        }

        // POST: StudentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
