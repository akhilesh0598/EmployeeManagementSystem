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
    public class DepartmentsService : IDepartmentsService
    {

        private readonly IDepartmentsRepository _departmentsRepository;

        public DepartmentsService(IDepartmentsRepository departmentsRepository)
        {
            _departmentsRepository = departmentsRepository;
        }

        public List<DepartmentResponse> GetAll()
        {
            var departments = _departmentsRepository.GetAll().Select(d => new DepartmentResponse()
            {
                Id = d.Id,
                Name = d.Name
            }).ToList();
            return departments;
        }

        public DepartmentResponse Get(int departmentId)
        {
            var department = _departmentsRepository.Get(departmentId);
            return new DepartmentResponse()
            {
                Id = department.Id,
                Name = department.Name
            };

        }

        public int Add(DepartmentRequest departmentRequest)
        {
            var department = new Department()
            {
                Name = departmentRequest.Name
            };
            int departmentId = _departmentsRepository.Add(department);
            return departmentId;

        }

        public void Update(int departmentId, DepartmentRequest departmentRequest)
        {
            var department = new Department()
            {
                Name = departmentRequest.Name
            };
            _departmentsRepository.Update(departmentId, department);
        }

        public void Delete(int departmentId)
        {
            _departmentsRepository.Delete(departmentId);
        }

        public bool ValidateId(int departmentId)
        {
            var department=_departmentsRepository.Get(departmentId);
            if (department == null)
                return false;
            return true;
        }
    }
}
