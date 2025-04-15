using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace be.Dtos.Auth
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Username Is Required")]
        [JsonPropertyName("username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password Is Required")]
        [JsonPropertyName("password")]
        public string Password { get; set; }        
    }
}