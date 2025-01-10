using System.ComponentModel.DataAnnotations;

namespace MyOwnPortfolio.ApiService.Entities
{
    public class Skill : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
