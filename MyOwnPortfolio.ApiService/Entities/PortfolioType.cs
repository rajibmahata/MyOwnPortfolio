using System.ComponentModel.DataAnnotations;

namespace MyOwnPortfolio.ApiService.Entities
{
    public class PortfolioType : BaseEntity
    {
     
        [Required]
        public string Type { get; set; }
       
    }
}
