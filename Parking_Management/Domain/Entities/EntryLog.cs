using System;
using System.Collections.Generic;

namespace Parking_Management.Domain.Entities;

public partial class EntryLog
{
    public int Id { get; set; }

    public int CardId { get; set; }

    public string PlateNumber { get; set; } = null!;

    public string VehicleType { get; set; } = null!;

    public DateTime? EntryTime { get; set; }

    public string EntryLane { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Card Card { get; set; } = null!;

    public virtual ICollection<ExitLog> ExitLogs { get; set; } = new List<ExitLog>();
}
