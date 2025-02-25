using System;
using System.Collections.Generic;

namespace Parking_Management.Models;

public partial class Gate
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Computer> Computers { get; set; } = new List<Computer>();
}
