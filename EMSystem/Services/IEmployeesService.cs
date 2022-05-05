using EMSystem.Models.Requests;
using EMSystem.Models.Responses;
using System.Collections.Generic;

namespace EMSystem.Services
{
    public interface IEmployeesService
    {
        int Add(EmployeeRequest employeeRequest);
        void Delete(int departmentId);
        EmployeeResponse Get(int employeeId);
        List<EmployeeResponse> GetAll();
        void Update(int employeeId, EmployeeRequest employeeRequest);
        bool ValidateId(int employeeId);
    }
}