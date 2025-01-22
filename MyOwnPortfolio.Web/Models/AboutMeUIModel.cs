namespace MyOwnPortfolio.Web.Models
{
    /// <summary>
    /// Represents the UI model for the "About Me" section.
    /// </summary>
    public class AboutMeUIModel
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public  string? ID { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// Gets or sets the first address line.
        /// </summary>
        public  string? Address1 { get; set; }

        /// <summary>
        /// Gets or sets the second address line.
        /// </summary>
        public string? Address2 { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        public string? City { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public string? State { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        public string? Country { get; set; }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        public string? Zip { get; set; }

        /// <summary>
        /// Gets or sets the contact number.
        /// </summary>
        public required string ContactNumber { get; set; }

        /// <summary>
        /// Gets or sets the Skype ID.
        /// </summary>
        public string? SkypeId { get; set; }

        /// <summary>
        /// Gets or sets the LinkedIn profile URL.
        /// </summary>
        public string? Linkedin { get; set; }

        /// <summary>
        /// Gets or sets the Twitter profile URL.
        /// </summary>
        public string? Twitter { get; set; }

        /// <summary>
        /// Gets or sets other contact information.
        /// </summary>
        public string? Others { get; set; }

        /// <summary>
        /// Gets or sets the GitHub profile URL.
        /// </summary>
        public string? Github { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the short title.
        /// </summary>
        public string? ShortTitle { get; set; }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        public string? Summary { get; set; }

        /// <summary>
        /// Gets or sets the count of happy clients.
        /// </summary>
        public string? HappyClientsCount { get; set; }

        /// <summary>
        /// Gets or sets the short summary of happy clients.
        /// </summary>
        public string? HappyClientsShortSummary { get; set; }

        /// <summary>
        /// Gets or sets the count of projects.
        /// </summary>
        public string? ProjectsCount { get; set; }

        /// <summary>
        /// Gets or sets the short summary of projects.
        /// </summary>
        public string? ProjectsShortSummary { get; set; }

        /// <summary>
        /// Gets or sets the years of experience.
        /// </summary>
        public string? YearsOfExperience { get; set; }

        /// <summary>
        /// Gets or sets the short summary of years of experience.
        /// </summary>
        public string? YearsOfExperienceShortSummary { get; set; }

        /// <summary>
        /// Gets or sets the awards.
        /// </summary>
        public string? Awards { get; set; }

        /// <summary>
        /// Gets or sets the short summary of awards.
        /// </summary>
        public string? AwardsShortSummary { get; set; }
    }
}
