using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMSystem.Models.Requests
{
    public class EmployeeRequest
    {
        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Qualification { get; set; }
        public int ContactNumber { get; set; }
        [Required]
        public int DepartmentId { get; set; }
    }
}
