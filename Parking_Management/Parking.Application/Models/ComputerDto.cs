using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Parking_Management.Parking.Application.Models
{
    public class ComputerDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string IpAddress { get; set; } = null!;
        public int GateId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class CreateComputerDto
    {
        public string Name { get; set; }
        public string IpAddress { get; set; } = null!;
        public int GateId { get; set; }
    }

    public class UpdateComputerDto
    {
        public string Name { get; set; }
        public string IpAddress { get; set; } = null!;
        public int GateId { get; set; }
    }
}