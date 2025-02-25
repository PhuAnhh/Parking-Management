using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Parking_Management.Models;

public partial class Computer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string IpAddress { get; set; } = null!;

    public int GateId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Camera> Cameras { get; set; } = new List<Camera>();

    public virtual ICollection<ControlUnit> ControlUnits { get; set; } = new List<ControlUnit>();

    public virtual Gate Gate { get; set; } = null!;

    public virtual ICollection<Lane> Lanes { get; set; } = new List<Lane>();

    public virtual ICollection<Led> Leds { get; set; } = new List<Led>();
}
