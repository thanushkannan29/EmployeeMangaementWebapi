using EmployeeManagementWebApi.Contexts;
using EmployeeManagementWebApi.Interfaces;
using EmployeeManagementWebApi.Models;
using EmployeeManagementWebApi.Repositories;
using EmployeeManagementWebApi.Services;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EmployeeContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Development"));
});



/*Create an Web API that will help us manage the Employees. The roles are Employee and Admin

Employee data that has to stored are Id, Name, DateOfBirth, DepartmnetId
Department will have Id, Name
User will have EmployeeId, Password, PasswordHash and Role

Employee can register with an endpoint
Also have a way to display employee data, Please populate the department name while displaying the employee. Paginate the output.

You can choose to use LINQ or SP for your actions

Note: Password has to be encrypted 
 * 
 * 
 */
// Configure the HTTP request pipeline.
builder.Services.AddScoped<IRepository<int, Department>, Respository<int, Department>>();
builder.Services.AddScoped<IRepository<int, Employee>, Respository<int, Employee>>();
builder.Services.AddScoped<IRepository<string, User>, Respository<string, User>>();

builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IPasswordService, PasswordService>();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
