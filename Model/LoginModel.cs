using System.ComponentModel.DataAnnotations;

namespace MyOwnPortfolio.Model
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberPassword {get;set;}
    }
}
