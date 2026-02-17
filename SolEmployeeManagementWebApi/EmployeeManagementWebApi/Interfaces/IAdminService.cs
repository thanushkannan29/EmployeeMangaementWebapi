using EmployeeManagementWebApi.Models.DTOs;

namespace EmployeeManagementWebApi.Interfaces
{
    public interface IAdminService
    {
        CreateAdminResponseDto CreateAdmin(CreateAdminRequestDto request);
    }
}
