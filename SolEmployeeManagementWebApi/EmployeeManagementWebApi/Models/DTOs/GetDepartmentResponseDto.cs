namespace EmployeeManagementWebApi.Models.DTOs
{
    public class GetDepartmentResponseDto
    {
        public List<Department>? Departments { get; set; }
        public int PageNumber { get; set; }
        public int NumberOfRecords { get; set; }
    }
}
