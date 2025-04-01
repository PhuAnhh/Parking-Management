using System;
using System.Collections.Generic;

namespace Parking_Management.Parking.Domain.Entities;   

public partial class Led
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ComputerId { get; set; }

    public string Type { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Computer Computer { get; set; } = null!;
}
