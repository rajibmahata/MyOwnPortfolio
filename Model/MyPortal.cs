using System.ComponentModel.DataAnnotations.Schema;

namespace MyOwnPortfolio.Model
{
    public class MyPortal :BaseModel
    {
        public string Username { get; set; }
        public string Passwordhash { get; set; }
        public string Passwordsalt { get; set; }

        public AboutMe? AboutMe { get; set; }
    }
}
