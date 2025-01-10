using System.ComponentModel.DataAnnotations.Schema;

namespace MyOwnPortfolio.ApiService.Entities
{
    public class PortfolioUser : BaseEntity
    {
       // [ForeignKey("Portfolio")]
        public long PortfolioID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string SkypeId { get; set; }
        public string Linkedin { get; set; }
        public string Twitter { get; set; }
        public string Others { get; set; }
        public MyPortal Portfolio { get; set; }
    }
}
