namespace EmployeeManagementWebApi.Models.DTOs
{
    public class GetEmployeeResponseDto
    {
        public List<Employee>? Employees { get; set; }

        public int PageNumber { get; set; }
        public int NumberOfRecords { get; set; }
    }
}
