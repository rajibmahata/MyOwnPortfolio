using System.ComponentModel.DataAnnotations.Schema;

namespace MyOwnPortfolio.ApiService.Entities
{
    public class MyPortal :BaseEntity
    {
        public string Username { get; set; }
        public string Passwordhash { get; set; }
        public string Passwordsalt { get; set; }

        [NotMapped]
        public AboutMe? AboutMe { get; set; }

      
    }
}
