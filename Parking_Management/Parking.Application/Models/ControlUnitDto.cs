using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Parking_Management.Parking.Application.Models;

public partial class ControlUnitDto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string ConnectionProtocol { get; set; } = null!;
    public int ComputerId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public class CreateControlUnitDto
{
    public string Name { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string ConnectionProtocol { get; set; } = null!;
    public int ComputerId { get; set; }
}

public class UpdateControlUnitDto
{
    public string Name { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string ConnectionProtocol { get; set; } = null!;
    public int ComputerId { get; set; }
}