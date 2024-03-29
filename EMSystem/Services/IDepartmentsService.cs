﻿using EMSystem.Models.Requests;
using EMSystem.Models.Responses;
using System.Collections.Generic;

namespace EMSystem.Services
{
    public interface IDepartmentsService
    {
        int Add(DepartmentRequest departmentRequest);
        void Delete(int departmentId);
        DepartmentResponse Get(int departmentId);
        DepartmentResponse Get(string departmentName);
        List<DepartmentResponse> GetAll();
        void Update(int departmentId, DepartmentRequest departmentRequest);
        bool ValidateId(int departmentId);
        bool ValidateName(string departmentName);
    }
}