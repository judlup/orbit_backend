using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_api.Model
{
    public class Student
    {
        public int Id { get; set; } = 0;
        public string Username { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int Age { get; set; } = 0;
        public string Career { get; set; } = "";
    }
}
