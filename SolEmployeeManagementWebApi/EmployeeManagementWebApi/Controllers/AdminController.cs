using EmployeeManagementWebApi.Interfaces;
using EmployeeManagementWebApi.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementWebApi.Controllers
{
    [Route("api/admin")]
    [ApiController]

    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public AdminController(
            IAdminService adminService,
            IEmployeeService employeeService,
            IDepartmentService departmentService)
        {
            _adminService = adminService;
            _employeeService = employeeService;
            _departmentService = departmentService;
        }



        [AllowAnonymous]
        [HttpPost("createadmin")]
        public IActionResult CreateAdmin(CreateAdminRequestDto request)
        {
            try
            {
                var result = _adminService.CreateAdmin(request);
                return Created($"https://baseurl/admin/{result.AdminId}", result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost("createemployee")]
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
        public IActionResult GetAllEmployees(GetEmployeeRequestDto request)
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



        [HttpPost("createdepartment")]
        public IActionResult CreateDepartment(CreateDepartmentRequestDto request)
        {
            try
            {
                return Ok(_departmentService.CreateDepartment(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("getalldepartment")]
        public IActionResult GetAllDepartments(GetDepartmentResquestDto request)
        {
            try
            {
                return Ok(_departmentService.GetDepartments(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
