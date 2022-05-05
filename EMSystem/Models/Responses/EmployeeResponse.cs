using EMSystem.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMSystem.Models.Responses
{
    public class EmployeeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Qualification { get; set; }
        public int ContactNumber { get; set; }
        public DepartmentResponse Department { get; set; }
    }
}
