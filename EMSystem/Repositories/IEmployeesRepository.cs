using EMSystem.Models.DB;
using EMSystem.Models.Responses;
using System.Collections.Generic;

namespace EMSystem.Repositories
{
    public interface IEmployeesRepository
    {
        int Add(Employee employee);
        void Delete(int employeeId);
        Employee Get(int employeeId);
        List<Employee> GetAll();
        void Update(int employeeId, Employee employee);

        List<EmployeeResponse> GetByDepartmentName(string departmentName);
    }
}