using System.ComponentModel.DataAnnotations;

namespace server.DTOs
{
    public class LoginDto
    {
        [Required] public string username { get; set; }
        [Required] public string password { get; set; }
    }
}