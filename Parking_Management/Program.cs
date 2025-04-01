using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Parking_Management.Parking.Application.Repositories;
using Parking_Management.Parking.Application.Services;
using Parking_Management.Parking.Application.Services.Abstractions;
using Parking_Management.Parking.Persistence.DbContexts;
using Parking_Management.Parking.Persistence.Repositories;

using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        options.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
    });


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = configuration["Jwt:Issuer"],
        ValidAudience = configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
    };
});

builder.Services.AddAuthorization(options =>
{
    // Policy dựa trên Role
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("Manager", policy => policy.RequireRole("Admin", "Manager"));
    options.AddPolicy("User", policy => policy.RequireRole("Admin", "Manager", "User"));

    // Policy dựa trên Permission
    options.AddPolicy("ManageLanes", policy =>
        policy.RequireClaim("permission", "lanes.create", "lanes.update"));

    options.AddPolicy("ManageGates", policy =>
        policy.RequireClaim("permission", "gates.create", "gates.update"));

    options.AddPolicy("ViewReports", policy =>
        policy.RequireClaim("permission", "reports.view"));

    options.AddPolicy("ManageUsers", policy =>
        policy.RequireClaim("permission", "users.manage"));
});

// Add services to the container.
builder.Services.AddDbContext<ParkingManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                         .AllowAnyMethod()
                         .AllowAnyHeader());
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

    
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICameraService, CameraService>();
builder.Services.AddScoped<IComputerService, ComputerService>();
builder.Services.AddScoped<IControlUnitService, ControlUnitService>();
builder.Services.AddScoped<IGateService, GateService>();
builder.Services.AddScoped<ILaneService, LaneService>();
builder.Services.AddScoped<ILedService, LedService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
