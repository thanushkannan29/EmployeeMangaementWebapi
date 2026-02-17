using EmployeeManagementWebApi.Interfaces;
using EmployeeManagementWebApi.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementWebApi.Controllers
{
    [Route("api/employee")]
    [ApiController]

    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("create")]
        public IActionResult CreateEmployee(CreateEmployeeRequestDto request)
        {
            try
            {
                var result = _employeeService.CreateEmployee(request);
                return Created($"https://baseurl/employee/{result.EmployeeId}", result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("getallemployee")]
        public IActionResult GetEmployees(GetEmployeeRequestDto request)
        {
            try
            {
                var response = _employeeService.GetEmployees(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
