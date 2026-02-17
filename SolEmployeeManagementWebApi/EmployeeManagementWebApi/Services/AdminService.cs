using EmployeeManagementWebApi.Contexts;
using EmployeeManagementWebApi.Interfaces;
using EmployeeManagementWebApi.Models;
using EmployeeManagementWebApi.Models.DTOs;

namespace EmployeeManagementWebApi.Services
{
    public class AdminService : IAdminService
    {
        private readonly EmployeeContext _context;
        private readonly IPasswordService _passwordService;

        public AdminService(EmployeeContext context, IPasswordService passwordService)
        {
            _context = context;
            _passwordService = passwordService;
        }

        public CreateAdminResponseDto CreateAdmin(CreateAdminRequestDto request)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var encryptedPassword = _passwordService
                    .HashPassword(request.Password, null, out byte[] hashKey);

                var user = new User
                {
                    
                    Password = encryptedPassword,
                    PasswordHash = hashKey,
                    Role = "Admin"
                };

                _context.Users.Add(user);
                _context.SaveChanges();

                return new CreateAdminResponseDto
                {
                    AdminId = user.Id
                };
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }
    }

}
