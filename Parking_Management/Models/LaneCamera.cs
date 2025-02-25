using System;
using System.Collections.Generic;

namespace Parking_Management.Models;

public partial class LaneCamera
{
    public int LaneId { get; set; }

    public int CameraId { get; set; }

    public string Purpose { get; set; } = null!;

    public string CameraType { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Camera Camera { get; set; } = null!;

    public virtual Lane Lane { get; set; } = null!;
}
