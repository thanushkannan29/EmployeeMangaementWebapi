using EmployeeManagementWebApi.Models.DTOs;

namespace EmployeeManagementWebApi.Interfaces
{
    public interface IEmployeeService
    {
        public CreateEmployeeResponseDto CreateEmployee(CreateEmployeeRequestDto request);

        public GetEmployeeResponseDto GetEmployees(GetEmployeeRequestDto request);
    }
}
