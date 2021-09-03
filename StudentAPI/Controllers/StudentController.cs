using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Data;
using StudentAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext _dbContext;

            public StudentController(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/<StudentController> GET ALL STUDENTS
        [HttpGet]
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _dbContext.Students.ToListAsync();
        }

        //GET STUDENT BY ID
        [HttpGet("{id}")]

        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = _dbContext.Students.FindAsync(id);
            if (await student == null) return NotFound();
            return await student;
        }
 
        // POST api/<StudentController> ADD STUDENT
        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent(Student student)    
        {
            await _dbContext.Students.AddAsync(student);
            var result = await _dbContext.SaveChangesAsync();
            return Ok(_dbContext.Students);

        }

        // PUT api/<StudentController>/5 UPDATE STUDENT RECORD by id
        [HttpPut("{id}")]
        
        public IActionResult Put(int id, [FromBody] Student student)
        {
            var entity = _dbContext.Students.Find(id);
            if(entity == null)
            {
                return NotFound("student does not exist");
            }
            else
            {
                entity.StudentId = student.StudentId;
                entity.StudentName = student.StudentName;
                entity.DateofBirth = student.DateOfBirth;
                entity.Gender = student.Gender;
                _dbContext.SaveChanges();
                return Ok(_dbContext.Students);

            }
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public IActionResult  Delete(int id)
        {
            var student = _dbContext.Students.Find(id);
            if(student == null)
            {
                return NotFound("student doesnt exist");

            }
            else
            {
                _dbContext.Students.Remove(student);
                _dbContext.SaveChanges();
                return Ok("Student Deleted Successsfull.....");
            }

        }
    }
}
