using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Parking_Management.Parking.Application.Models;

public class LedDto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int ComputerId { get; set; }
    public string Type { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public class CreateLedDto
{
    public string Name { get; set; } 
    public int ComputerId { get; set; }
    public string Type { get; set; }
}

public class UpdateLedDto
{
    public string Name { get; set; }
    public int ComputerId { get; set; }
    public string Type { get; set; }
}
