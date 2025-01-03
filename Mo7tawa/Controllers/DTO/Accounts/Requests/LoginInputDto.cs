using System.ComponentModel.DataAnnotations;

namespace Mo7tawa.Controllers.DTO.Accounts.Requests
{
    public class LoginInputDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
