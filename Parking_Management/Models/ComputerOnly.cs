using Microsoft.AspNetCore.Mvc;

namespace Parking_Management.Models
{
    public class ComputerOnly
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string IpAddress { get; set; } = null!;

        public int GateId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }


    }
}