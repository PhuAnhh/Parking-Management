using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Parking_Management.Parking.Application.Models
{
    public class CameraDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string IpAddress { get; set; } = null!;

        public string Resolution { get; set; } = null!;

        public string Type { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public int ComputerId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
        public class CreateCameraDto
        {
            public string Name { get; set; }
            public string IpAddress { get; set; } 
            public string Resolution { get; set; } 
            public string Type { get; set; }
            public string Username { get; set; } 
            public string Password { get; set; } 
            public int ComputerId { get; set; }
        }

        public class UpdateCameraDto
        {
            public string Name { get; set; }
            public string IpAddress { get; set; }
            public string Resolution { get; set; }
            public string Type { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public int ComputerId { get; set; }
        }
}
