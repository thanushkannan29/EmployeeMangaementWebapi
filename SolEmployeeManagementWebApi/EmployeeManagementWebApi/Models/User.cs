namespace EmployeeManagementWebApi.Models
{
    public class User
    {
        public Employee? Employee { get; set; }

        public int Id { get; set; }//can be employee or Admin ID

        public byte[] Password { get; set; }=Array.Empty<byte>();

        public byte[] PasswordHash { get; set;}=Array.Empty<byte>();

        public string Role { get; set; }=string.Empty;

    }
}
