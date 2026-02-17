using EmployeeManagementWebApi.Models.DTOs;

namespace EmployeeManagementWebApi.Interfaces
{
    public interface IDepartmentService
    {
        public CreateDepartmentResponseDto CreateDepartment(CreateDepartmentRequestDto request);

        public GetDepartmentResponseDto GetDepartments(GetDepartmentResquestDto request);
    }
}
