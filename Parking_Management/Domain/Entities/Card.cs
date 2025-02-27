using System;
using System.Collections.Generic;

namespace Parking_Management.Domain.Entities;

public partial class Card
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public int GroupId { get; set; }

    public int CustomerId { get; set; }

    public bool Deleted { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<EntryLog> EntryLogs { get; set; } = new List<EntryLog>();

    public virtual ICollection<ExitLog> ExitLogs { get; set; } = new List<ExitLog>();

    public virtual CardGroup Group { get; set; } = null!;
}
