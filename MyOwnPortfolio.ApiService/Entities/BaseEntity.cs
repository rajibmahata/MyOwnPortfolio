using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyOwnPortfolio.ApiService.Entities
{
    public class BaseEntity
    {
        [Key]
        public string ID { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime ModifiedDate { get; set; }

        [Required]
        public bool IsActive { get; set; }

    }
}
