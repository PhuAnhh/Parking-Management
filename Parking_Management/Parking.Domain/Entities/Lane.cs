using System;
using System.Collections.Generic;

namespace Parking_Management.Parking.Domain.Entities;   

public partial class Lane
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public int ComputerId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Computer Computer { get; set; } = null!;

    public virtual ICollection<LaneCamera> LaneCameras { get; set; } = new List<LaneCamera>();

    public virtual ICollection<LaneController> LaneControllers { get; set; } = new List<LaneController>();
}
