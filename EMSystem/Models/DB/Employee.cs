using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMSystem.Models.DB
{
    public class Employee
    {
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string Name { get; set; }
        public string  Surname { get; set; }
        public string Address { get; set; }
        public string Qualification { get; set; }
        public int ContactNumber { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

    }
}
