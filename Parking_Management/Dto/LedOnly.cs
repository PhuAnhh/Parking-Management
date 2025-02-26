﻿using System;
using System.Collections.Generic;

namespace Parking_Management.Models;

public partial class LedOnly
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ComputerId { get; set; }

    public string Type { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

}
