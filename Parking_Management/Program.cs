using Microsoft.EntityFrameworkCore;
<<<<<<< Updated upstream
using Parking_Management.Models;
=======
using Parking_Management.Business;
using Parking_Management.Business.Repositories;
using Parking_Management.Business.Services;
using Parking_Management.Domain.Entities;
using Parking_Management.Domain.Interface;
>>>>>>> Stashed changes

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ParkingManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
 
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

<<<<<<< Updated upstream
=======
builder.Services.AddScoped<IGateRepository, GateRepository>();
builder.Services.AddScoped<IGateService, GateService>();

builder.Services.AddScoped<IComputerRepository, ComputerRepository>();
builder.Services.AddScoped<IComputerService, ComputerService>();

builder.Services.AddScoped<ICameraRepository, CameraRepository>();
builder.Services.AddScoped<ICameraService, CameraService>();

builder.Services.AddScoped<IControlUnitRepository, ControlUnitRepository>();
builder.Services.AddScoped<IControlUnitService, ControlUnitService>();

builder.Services.AddScoped<ILaneRepository, LaneRepository>();
builder.Services.AddScoped<ILaneService, LaneService>();

builder.Services.AddScoped<ILedRepository, LedRepository>();
builder.Services.AddScoped<ILedService, LedService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();




>>>>>>> Stashed changes
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
