using System.ComponentModel.DataAnnotations;

namespace MyOwnPortfolio.Model
{
    public class BaseModel
    {
        public string ID { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public bool IsActive { get; set; }
    }
}
