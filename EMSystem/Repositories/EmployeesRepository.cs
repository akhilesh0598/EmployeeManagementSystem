﻿using EMSystem.Data;
using EMSystem.Models.DB;
using EMSystem.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMSystem.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly EMStoreContext _context;

        public EmployeesRepository(EMStoreContext context)
        {
            _context = context;
        }

        public List<Employee> GetAll()
        {
            var employees = _context.Employees.ToList();
            return employees;
        }

        public Employee Get(int employeeId)
        {
            var employee = _context.Employees.FirstOrDefault(d => d.Id == employeeId);
            return employee;
        }

        public int Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee.Id;

        }

        public void Update(int employeeId, Employee employee)
        {
            var nonUpdatedEmployee = _context.Employees.Find(employeeId);
            nonUpdatedEmployee.Name = employee.Name;
            nonUpdatedEmployee.Surname = employee.Surname;
            nonUpdatedEmployee.Qualification = employee.Qualification;
            nonUpdatedEmployee.Address = employee.Address;
            nonUpdatedEmployee.ContactNumber = employee.ContactNumber;
            nonUpdatedEmployee.DepartmentId = employee.DepartmentId;
            _context.SaveChanges();
        }

        public void Delete(int employeeId)
        {
            var employee = _context.Employees.Find(employeeId);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }
        public List<EmployeeResponse> GetByDepartmentName(string departmentName)
        {
            var employees = _context.Employees.Join(_context.Departments,e=>e.DepartmentId
            ,d=>d.Id,(e,d)=>
            new EmployeeResponse{
                Id = e.Id,
                Name = e.Name,
                Surname = e.Surname,
                Qualification = e.Qualification,
                Address = e.Address,
                ContactNumber = e.ContactNumber,
                Department = new DepartmentResponse
                {
                    Id=d.Id,
                    Name=d.Name
                }

            }).Where(x => x.Department.Name==departmentName).ToList();
            return employees;
        }
    }
}
