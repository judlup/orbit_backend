using backend_api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            if (_oStudents.Count == 0)
            {
                return NotFound("No list found");
            }
            return Ok(_oStudents);
        }

        [HttpGet("GetStudent")]
        public IActionResult Get(int id)
        {
            var oStudent = _oStudents.SingleOrDefault(x => x.Id == id);
            if(oStudent == null)
            {
                return NotFound("No student found.");
            }

            return Ok(oStudent);
        }

        [HttpPost]
        public IActionResult Save(Student oStudent)
        {
            _oStudents.Add(oStudent);
            if(_oStudents.Count == 0)
            {
                return NotFound("No list found");
            }

            return Ok(_oStudents);
        }

        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            var oStudent = _oStudents.SingleOrDefault(x => x.Id == id);
            if(oStudent == null)
            {
                return NotFound("No student found");
            }
            _oStudents.Remove(oStudent);

            if(_oStudents.Count == 0)
            {
                return NotFound("No list found");
            }

            return Ok(_oStudents);
        }

        [HttpPut]
        public IActionResult UpdateStudent(Student oStudent)
        {
            Student student = _oStudents.SingleOrDefault(x => x.Id == oStudent.Id);
            if (oStudent == null)
            {
                return NotFound("No student found");
            }

            student.Username = oStudent.Username;
            student.FirstName = oStudent.FirstName;
            student.LastName = oStudent.LastName;
            student.Age = oStudent.Age;
            student.Career = oStudent.Career;

            if (_oStudents.Count == 0)
            {
                return NotFound("No list found");
            }

            return Ok(_oStudents);
        }        
    }
}
