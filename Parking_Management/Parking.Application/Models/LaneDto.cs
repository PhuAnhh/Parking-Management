using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Parking_Management.Parking.Application.Models;

public class LaneDto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Type { get; set; } = null!;
    public int ComputerId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public class CreateLaneDto
{
    public string Name { get; set; }
    public string Type { get; set; }
    public int ComputerId { get; set; }
}

public class UpdateLaneDto
{
    public string Name { get; set; }
    public string Type { get; set; }
    public int ComputerId { get; set; }
}
