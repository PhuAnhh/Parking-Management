using System;
using System.Collections.Generic;

namespace Parking_Management.Parking.Domain.Entities;

public partial class ExitLog
{
    public int Id { get; set; }

    public int CardId { get; set; }

    public int EntryId { get; set; }

    public string PlateNumber { get; set; } = null!;

    public string VehicleType { get; set; } = null!;

    public DateTime? ExitTime { get; set; }

    public string ExitLane { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Card Card { get; set; } = null!;

    public virtual EntryLog Entry { get; set; } = null!;
}
