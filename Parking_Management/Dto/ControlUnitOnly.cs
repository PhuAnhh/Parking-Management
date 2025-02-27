using System;

namespace Parking_Management.Dto;

public partial class ControlUnitOnly
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
}