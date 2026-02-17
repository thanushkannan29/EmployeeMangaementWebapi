using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementWebApi.Models.DTOs
{
    public class CreateEmployeeRequestDto
    {

        [Required(ErrorMessage ="Employee Name Can't Be Empty")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Employee not empty and check format")]
        public DateOnly DateofBrith { get; set; }
        [Required(ErrorMessage = "Employee Department ID Can't Be Empty")]
        public int DepartmentId { get; set; }
       
        [Required(ErrorMessage = "Password name cannot be empty")]
        public string Password { get; set; }=string.Empty;

    }
}
