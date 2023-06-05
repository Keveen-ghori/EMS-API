using EMS.Data.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using EMS.Infrastructure.EmployeeRepository;
using EMS.Application.Contract;
using EMS.Application.Common;
using EMS.Application;
using AutoMapper;
using System.Reflection;
using MediatR;
using EMS.Application.DTO.Employee;
using EMS.Application.Features.Employees.Handlers.Queruies;
using EMS.Application.Profiles;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.ConfigureApplicationServices();
// Add services to the container.

//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<EmployeeManagementContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddControllers();
builder.Services.AddControllers().AddNewtonsoftJson();

//Register interface class
builder.Services.AddScoped<IunitOfWorks, UnitOfWorks>();
builder.Services.AddMediatR(typeof(GetEmployeeListsHandlers).Assembly, typeof(GetEmployeeDetailsHandler).Assembly);
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddScoped<IMapper, Mapper>();
//builder.Services.AddScoped<IRequestHandler<GetEmployeeListRequests, List<EmployeeDto>>, GetEmployeeListsHandlers>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
