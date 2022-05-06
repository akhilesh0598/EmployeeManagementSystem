using EMSystem.Data;
using EMSystem.Models.DB;
using EMSystem.Models.Requests;
using EMSystem.Models.Responses;
using EMSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMSystem.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IDepartmentsService _departmentsService;

        public EmployeesService(IEmployeesRepository employeesRepository,IDepartmentsService departmentsService)
        {
            _employeesRepository = employeesRepository;
            _departmentsService = departmentsService;
        }

        public List<EmployeeResponse> GetAll()
        {
            var employees = _employeesRepository.GetAll().Select(e => new EmployeeResponse()
            {
                Id = e.Id,
                Name = e.Name,
                Surname = e.Surname,
                Qualification = e.Qualification,
                Address = e.Address,
                ContactNumber = e.ContactNumber,
                Department =_departmentsService.Get(e.DepartmentId)
            }).ToList();
            return employees;
        }

        public EmployeeResponse Get(int employeeId)
        {
            var employee = _employeesRepository.Get(employeeId);
            return new EmployeeResponse()
            {
                Id = employee.Id,
                Name = employee.Name,
                Surname = employee.Surname,
                Qualification = employee.Qualification,
                Address = employee.Address,
                ContactNumber = employee.ContactNumber,
                Department = _departmentsService.Get(employee.DepartmentId)
            };
        }

        public int Add(EmployeeRequest employeeRequest)
        {
            var employee = new Employee()
            {

                Name = employeeRequest.Name,
                Surname = employeeRequest.Surname,
                Qualification = employeeRequest.Qualification,
                Address = employeeRequest.Address,
                ContactNumber = employeeRequest.ContactNumber,
                DepartmentId = employeeRequest.DepartmentId

            };
            int employeeId = _employeesRepository.Add(employee);
            return employeeId;

        }

        public void Update(int employeeId, EmployeeRequest employeeRequest)
        {
            var employee = new Employee()
            {
                Name = employeeRequest.Name,
                Surname = employeeRequest.Surname,
                Qualification = employeeRequest.Qualification,
                Address = employeeRequest.Address,
                ContactNumber = employeeRequest.ContactNumber,
                DepartmentId = employeeRequest.DepartmentId

            };
            _employeesRepository.Update(employeeId, employee);
        }

        public void Delete(int departmentId)
        {
            _employeesRepository.Delete(departmentId);

        }

        public bool ValidateId(int employeeId)
        {
            var employee = _employeesRepository.Get(employeeId);
            if (employee == null)
                return false;
            return true;
        }
        public List<EmployeeResponse> GetByDepartmentName(string departmentName)
        {
            var department = _departmentsService.Get(departmentName);
            var employees = _employeesRepository.GetByDepartmentId(department.Id)
                .Select(e => new EmployeeResponse()
            {
                Id = e.Id,
                Name = e.Name,
                Surname = e.Surname,
                Qualification = e.Qualification,
                Address = e.Address,
                ContactNumber = e.ContactNumber,
                Department = department
            }).ToList(); ;
            return employees;
        }
    }
}
