using System;
using System.Collections.Generic;

namespace Parking_Management.Parking.Domain.Entities;

public partial class LaneController
{
    public int LaneId { get; set; }

    public int ControlUnitId { get; set; }

    public string Input { get; set; } = null!;

    public string Barrier { get; set; } = null!;

    public string Alarm { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ControlUnit ControlUnit { get; set; } = null!;

    public virtual Lane Lane { get; set; } = null!;
}
