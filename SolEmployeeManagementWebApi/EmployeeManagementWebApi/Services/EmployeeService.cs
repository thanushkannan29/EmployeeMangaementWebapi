using EmployeeManagementWebApi.Contexts;
using EmployeeManagementWebApi.Exceptions;
using EmployeeManagementWebApi.Interfaces;
using EmployeeManagementWebApi.Models;
using EmployeeManagementWebApi.Models.DTOs;

using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementWebApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeContext _context;
        private readonly IPasswordService _passwordService;

        public EmployeeService(EmployeeContext context,IPasswordService passwordService) 
        {
            _context = context;
            _passwordService=passwordService;

        }
        public CreateEmployeeResponseDto CreateEmployee(CreateEmployeeRequestDto request)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var encryptedPassword = _passwordService.HashPassword(
                    request.Password, null, out byte[] hashkey);

                var employee = new Employee
                {
                    Name = request.Name,
                    DateofBrith = request.DateofBrith,
                    DepartmentId = request.DepartmentId
                };

                _context.Employees.Add(employee);
                _context.SaveChanges();  

                var user = new User
                {
                    Id = employee.Id,    
                    Password = encryptedPassword,
                    PasswordHash = hashkey,
                    Role = "Employee"
                };

                _context.Users.Add(user);
                _context.SaveChanges();

                transaction.Commit();

                return new CreateEmployeeResponseDto
                {
                    EmployeeId = employee.Id
                };
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public GetEmployeeResponseDto GetEmployees(GetEmployeeRequestDto request)
        {
            var employees = _context.Employees.FromSqlRaw("EXEC proc_Employee_pagination {0}, {1}", ((request.PageNumber - 1) * request.PageSize), request.PageSize).ToList();
     
            if (employees == null || employees.Count == 0)
            {
                throw new EntityNotFoundException("Employee");
            }

            return new GetEmployeeResponseDto
            {
                Employees = employees,
                PageNumber = request.PageNumber,
                NumberOfRecords = employees.Count
            };
        }

    }
}
