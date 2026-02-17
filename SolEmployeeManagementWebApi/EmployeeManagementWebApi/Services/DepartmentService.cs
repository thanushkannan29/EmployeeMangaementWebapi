using EmployeeManagementWebApi.Contexts;
using EmployeeManagementWebApi.Exceptions;
using EmployeeManagementWebApi.Interfaces;
using EmployeeManagementWebApi.Models;
using EmployeeManagementWebApi.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementWebApi.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly EmployeeContext _context;

        public DepartmentService(EmployeeContext context)
        {
            _context = context;
        }

        public CreateDepartmentResponseDto CreateDepartment(CreateDepartmentRequestDto request)
        {

            if (_context.Departments.Any(d => d.Name == request.Name))
                throw new DuplicateEntityException("Department already exists");

            try
            {
                var department = new Department
                {
                    Name = request.Name
                };

                _context.Departments.Add(department);
                _context.SaveChanges();

                return new CreateDepartmentResponseDto
                {
                    DepartmentId = department.Id
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GetDepartmentResponseDto GetDepartments(GetDepartmentResquestDto request)
        {
            
            var departments = _context.Departments.FromSqlRaw("EXEC proc_Department_pagination {0}, {1}", ((request.PageNumber - 1) * request.PageSize), request.PageSize).ToList();

            if (departments.Count == 0)
                throw new EntityNotFoundException("Department");

            return new GetDepartmentResponseDto
            {
                Departments = departments,
                PageNumber = request.PageNumber,
                NumberOfRecords = departments.Count
            };
        }
    }

}
