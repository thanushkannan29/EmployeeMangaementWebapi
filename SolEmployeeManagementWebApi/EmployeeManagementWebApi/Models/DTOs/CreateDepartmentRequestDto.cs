using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementWebApi.Models.DTOs
{
    public class CreateDepartmentRequestDto
    {
        [Required(ErrorMessage = "Department name cannot be empty")]
        public string Name { get; set; } = string.Empty;


    }
}
