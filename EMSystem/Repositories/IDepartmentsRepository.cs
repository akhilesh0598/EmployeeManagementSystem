using EMSystem.Models.DB;
using System.Collections.Generic;

namespace EMSystem.Repositories
{
    public interface IDepartmentsRepository
    {
        int Add(Department department);
        void Delete(int departmentId);
        Department Get(int departmentId);
        Department Get(string departmentName);
        List<Department> GetAll();
        void Update(int departmentId, Department department);
    }
}