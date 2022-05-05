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
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentsService _departmentsService;
        public DepartmentsController(IDepartmentsService departmentsService)
        {
            _departmentsService = departmentsService;
        }
        // GET: api/<DepartmentsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_departmentsService.GetAll());
        }

        // GET api/<DepartmentsController>/5
        [HttpGet("{departmentId}")]
        public IActionResult Get(int departmentId)
        {
            try
            {
                if (!_departmentsService.ValidateId(departmentId))
                    throw new IdNotFoundException($"In Department Entity Id '{departmentId}' not found");
                var departmentResponse = _departmentsService.Get(departmentId);
                return Ok(departmentResponse);
            }
            catch (IdNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // POST api/<DepartmentsController>
        [HttpPost]
        public IActionResult Post([FromBody] DepartmentRequest departmentRequest)
        {
            var departmentId=_departmentsService.Add(departmentRequest);
            return Created("~api/departments/", new { id = departmentId});
        }

        // PUT api/<DepartmentsController>/5
        [HttpPut("{departmentId}")]
        public IActionResult Put(int departmentId, [FromBody] DepartmentRequest departmentRequest)
        {
            try
            {
                if (!_departmentsService.ValidateId(departmentId))
                    throw new IdNotFoundException($"In Department Entity Id '{departmentId}' not found");
                _departmentsService.Update(departmentId, departmentRequest);
                return Ok(new { message = "Updated Successfully" });
            }
            catch (IdNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            
        }

        // DELETE api/<DepartmentsController>/5
        [HttpDelete("{departmentId}")]
        public IActionResult Delete(int departmentId)
        {
            try
            {
                if (!_departmentsService.ValidateId(departmentId))
                    throw new IdNotFoundException($"In Department Entity Id '{departmentId}' not found");
                _departmentsService.Delete(departmentId);
                return Ok(new { message = "Deleted Successfully" });
            }
            catch (IdNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
