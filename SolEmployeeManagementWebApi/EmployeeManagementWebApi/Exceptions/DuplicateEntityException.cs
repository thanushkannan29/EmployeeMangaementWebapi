namespace EmployeeManagementWebApi.Exceptions
{
    public class DuplicateEntityException:Exception
    {
        public DuplicateEntityException() : base("Department Already in database duplicate not allowed")
        {

        }
        public DuplicateEntityException(string message) : base($"{message} is duplicate " ){ }
    }
    
}
