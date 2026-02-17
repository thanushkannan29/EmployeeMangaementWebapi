namespace EmployeeManagementWebApi.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }=string.Empty;

        public DateOnly DateofBrith {  get; set; }

        public Department? Department { get; set; }

        public int DepartmentId { get; set; }

        public User? User { get; set; }
        
        



    }
}
