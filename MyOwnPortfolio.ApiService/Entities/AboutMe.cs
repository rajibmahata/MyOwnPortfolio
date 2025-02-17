﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MyOwnPortfolio.ApiService.Entities
{
    /// <summary>
    /// Represents the About Me section of the portfolio.
    /// </summary>
    public class AboutMe : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the associated portal.
        /// </summary>
        [ForeignKey("MyPortal")]
        public string MyPortalID { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the first address line.
        /// </summary>
        public string address1 { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the second address line.
        /// </summary>
        public string address2 { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public string State { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        public string Country { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        public string zip { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the contact number.
        /// </summary>
        public string ContactNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Skype ID.
        /// </summary>
        public string SkypeId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the LinkedIn profile URL.
        /// </summary>
        public string Linkedin { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Twitter profile URL.
        /// </summary>
        public string Twitter { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets other contact information.
        /// </summary>
        public string Others { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the GitHub profile URL.
        /// </summary>
        public string Github { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the short title.
        /// </summary>
        public string ShortTitle { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        public string Summary { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the count of happy clients.
        /// </summary>
        public string HappyClientsCount { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the short summary of happy clients.
        /// </summary>
        public string HappyClientsShortSummary { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the count of projects.
        /// </summary>
        public string ProjectsCount { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the short summary of projects.
        /// </summary>
        public string ProjectsShortSummary { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the years of experience.
        /// </summary>
        public string Yearsofexperience { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the short summary of years of experience.
        /// </summary>
        public string YearsofexperienceShortSummary { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the awards.
        /// </summary>
        public string Awards { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the short summary of awards.
        /// </summary>
        public string AwardsShortSummary { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the associated portal.
        /// </summary>
        [NotMapped]
        public MyPortal myPortal { get; set; }
    }
}
