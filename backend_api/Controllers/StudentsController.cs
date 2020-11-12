using backend_api.Data;
using backend_api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class StudentsController : ControllerBase
    {        
        List<Student> _oStudents = new List<Student>() {
            new Student()
            {
                Id = 1,
                Username = "Judlup",
                FirstName = "Julian",
                LastName = "Luna",
                Age = 28,
                Career = "Software development"
            },

            new Student()
            {
                Id = 2,
                Username = "nikol",
                FirstName = "Nikol",
                LastName = "Luna",
                Age = 3,
                Career = "Daughter"
            },

            new Student()
            {
                Id = 3,
                Username = "daniel",
                FirstName = "Daniel",
                LastName = "Luna",
                Age = 3,
                Career = "Brother"
            }
        };        

        [HttpGet]
        public IActionResult Gets()
        {
            using (var dbContext = new SqliteDbContext())
            {
                var students = dbContext.Students.ToListAsync();
                if (students == null)
                {
                    return NotFound("No student found");
                }
                return Ok(students);
            }            
        }

        [HttpGet("GetStudent")]
        public IActionResult Get(int id)
        {
            using (var dbContext = new SqliteDbContext())
            {
                var students = dbContext.Students.SingleOrDefault(x => x.Id  == id);
                if (students == null)
                {
                    return NotFound("No student found");
                }
                return Ok(students);
            }
        }

        [HttpPost]
        public IActionResult Save(Student oStudent)
        {            
            using (var dbContext = new SqliteDbContext())
            {
                Student student = new Student()
                {                    
                    Username = oStudent.Username,
                    FirstName = oStudent.FirstName,
                    LastName = oStudent.LastName,
                    Age = oStudent.Age,
                    Career = oStudent.Career
                };

                dbContext.Add(student);
                dbContext.SaveChanges();

                return Ok(student);
            }            
        }

        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            using (var dbContext = new SqliteDbContext())
            {                
                var Student = dbContext.Students.SingleOrDefault(x => x.Id == id);
                if (Student == null)
                {
                    return NotFound("No student found");
                }
                dbContext.Students.Remove(Student);
                dbContext.SaveChanges();
                return Ok("Register deleted successfully ");
            }
                                    
        }

        [HttpPut]
        public IActionResult UpdateStudent(Student Student)
        {
            using (var dbContext = new SqliteDbContext())
            {                
                dbContext.Update(Student);
                dbContext.SaveChanges();
                return Ok(Student);
            }         
        }        
    }
}
