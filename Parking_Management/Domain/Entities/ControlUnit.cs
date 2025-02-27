using System;
using System.Collections.Generic;

namespace Parking_Management.Domain.Entities;


public partial class ControlUnit
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string ConnectionProtocol { get; set; } = null!;

    public int ComputerId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Computer Computer { get; set; } = null!;

    public virtual ICollection<LaneController> LaneControllers { get; set; } = new List<LaneController>();
}
