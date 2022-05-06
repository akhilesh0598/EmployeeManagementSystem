using EMSystem.Exceptions;
using EMSystem.Models.Requests;
using EMSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EMSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesService _employeesService;
        private readonly IDepartmentsService _departmentsService;

        public EmployeesController(IEmployeesService employeesService,IDepartmentsService departmentsService)
        {
            _employeesService = employeesService;
            _departmentsService = departmentsService;
        }
        // GET: api/<EmployeesController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_employeesService.GetAll());
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{employeeId}")]
        public IActionResult Get(int employeeId)
        {
            try
            {
                if (!_employeesService.ValidateId(employeeId))
                    throw new IdNotFoundException($"In Employee Entity Id '{employeeId}' not found");
                var employeeResponse = _employeesService.Get(employeeId);
                return Ok(employeeResponse);
            }
            catch (IdNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public IActionResult Post([FromBody] EmployeeRequest employeeRequest)
        {
            try
            {
                if (!_departmentsService.ValidateId(employeeRequest.DepartmentId))
                    throw new IdNotFoundException($"In Department Id '{employeeRequest.DepartmentId}' not found");
                var employeeId = _employeesService.Add(employeeRequest);
                return Created("~api/employees/", new { id = employeeId });
            }
            catch (IdNotFoundException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{employeeId}")]
        public IActionResult Put(int employeeId, [FromBody] EmployeeRequest employeeRequest)
        {
            try
            {
                if (!_employeesService.ValidateId(employeeId))
                    throw new IdNotFoundException($"In Emplyee Entity Id '{employeeId}' not found");

                if (!_departmentsService.ValidateId(employeeRequest.DepartmentId))
                    throw new WrongDataInBodyException($"In Department Id '{employeeRequest.DepartmentId}' not found");
                _employeesService.Update(employeeId, employeeRequest);
                return Ok(new { message = "Updated Successfully" });
            }
            catch (IdNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch(WrongDataInBodyException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{employeeId}")]
        public IActionResult Delete(int employeeId)
        {
            try
            {
                if (!_employeesService.ValidateId(employeeId))
                    throw new IdNotFoundException($"In Employee Entity Id '{employeeId}' not found");
                _employeesService.Delete(employeeId);
                return Ok(new { message = "Deleted Successfully" });
            }
            catch (IdNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
        // GET api/<EmployeesController>/5
        [HttpGet("[action]/{departmentName}")]
        public IActionResult GetByDepartmentName(string departmentName)
        {
            try
            {
                if (!_departmentsService.ValidateName(departmentName))
                    throw new IdNotFoundException($"In Department Entity Name '{departmentName}' not found");
                var employeeResponse = _employeesService.GetByDepartmentName(departmentName);
                return Ok(employeeResponse);
            }
            catch (IdNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
