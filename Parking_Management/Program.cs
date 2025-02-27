using Microsoft.EntityFrameworkCore;
using Parking_Management.Business.Repositories;
using Parking_Management.Business.Services;
using Parking_Management.Domain.Entities;
using Parking_Management.Domain.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ParkingManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGateRepository, GateRepository>();
builder.Services.AddScoped<IGateService, GateService>();

builder.Services.AddScoped<IComputerRepository, ComputerRepository>();
builder.Services.AddScoped<IComputerService, ComputerService>();

builder.Services.AddScoped<ICameraRepository, CameraRepository>();
builder.Services.AddScoped<ICameraService, CameraService>();

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
