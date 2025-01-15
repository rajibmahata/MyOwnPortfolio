using System.ComponentModel.DataAnnotations;

namespace MyOwnPortfolio.Web.Models.RequestResponseModels
{
    public class LoginRequestModel
    {
        [Required(ErrorMessage = "Username is empty.")]
        public string Username { get; set; } 
        [Required(ErrorMessage = "Password is empty.")]
        public string Password { get; set; }
    }
}
