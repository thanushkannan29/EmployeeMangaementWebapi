using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementWebApi.Models.DTOs
{
    public class CreateAdminRequestDto
    {
        [Required(ErrorMessage = "Admin Name Can't Be Empty")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password name cannot be empty")]
        public string Password { get; set; } = string.Empty;
    }
}
