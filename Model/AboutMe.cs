using System.ComponentModel.DataAnnotations.Schema;

namespace MyOwnPortfolio.Model
{
    public class AboutMe : BaseModel
    {
        
        public string MyPortalID { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string zip { get; set; }
       
        public string ContactNumber { get; set; }
        public string SkypeId { get; set; }
        public string Linkedin { get; set; }
        public string Twitter { get; set; }
        public string Others { get; set; }

        public string Github { get; set; }
        public string Title { get; set; }
        public string ShortTitle { get; set; }
        public string Summary { get; set; }

        public string HappyClientsCount { get; set; }
        public string HappyClientsShortSummary { get; set; }
        public string ProjectsCount { get; set; }
        public string ProjectsShortSummary { get; set; }

        public string Yearsofexperience { get; set; }
        public string YearsofexperienceShortSummary { get; set; }

        public string Awards { get; set; }
        public string AwardsShortSummary { get; set; }

        [NotMapped]
        public MyPortal myPortal { get; set; }
    }
}
