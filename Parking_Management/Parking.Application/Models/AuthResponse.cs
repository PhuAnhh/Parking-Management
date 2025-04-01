namespace Parking_Management.Parking.Application.Models
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public string Username { get; set; }
        public List<string> Roles { get; set; }
        public List<string> Permissions { get; set; }
    }
}
