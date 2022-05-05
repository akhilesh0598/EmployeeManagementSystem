using EMSystem.Data;
using EMSystem.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMSystem.Repositories
{
    public class DepartmentsRepository : IDepartmentsRepository
    {

        private readonly EMStoreContext _context;

        public DepartmentsRepository(EMStoreContext context)
        {
            _context = context;
        }

        public List<Department> GetAll()
        {
            var departments = _context.Departments.ToList();
            return departments;
        }

        public Department Get(int departmentId)
        {
            var department = _context.Departments.FirstOrDefault(d => d.Id == departmentId);
            return department;
        }

        public int Add(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
            return department.Id;

        }

        public void Update(int departmentId, Department department)
        {
            var nonUpdatedDepartment = _context.Departments.Find(departmentId);
            nonUpdatedDepartment.Name = department.Name;
            _context.SaveChanges();
        }

        public void Delete(int departmentId)
        {
            var department = _context.Departments.Find(departmentId);
            _context.Departments.Remove(department);
            _context.SaveChanges();
        }
    }
}
