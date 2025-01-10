using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyOwnPortfolio.ApiService.Entities;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyOwnPortfolio.ApiService.Controllers
{

    /// <summary>
    /// Controller for managing portfolio types.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioTypeController : ControllerBase
    {
        private readonly MyPortfolioDbContext dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="PortfolioTypeController"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public PortfolioTypeController(MyPortfolioDbContext context)
        {
            dbContext = context;
        }

        /// <summary>
        /// Gets all portfolio types.
        /// </summary>
        /// <returns>A list of portfolio types.</returns>
        [HttpGet]
        public IEnumerable<PortfolioType> Get()
        {
            IEnumerable<PortfolioType> portfolioTypes;

            if (!dbContext.PortfolioTypes.Any())
            {
                dbContext.PortfolioTypes.AddRange(new PortfolioType[]
                {
                        new PortfolioType{ ID="1", Type="Individual" },
                        new PortfolioType{ ID="2", Type="Organizational" },
                });
                dbContext.SaveChanges();
            }
            portfolioTypes = dbContext.PortfolioTypes.ToList();

            return portfolioTypes;
        }

        /// <summary>
        /// Gets a portfolio type by ID.
        /// </summary>
        /// <param name="id">The ID of the portfolio type.</param>
        /// <returns>A portfolio type.</returns>
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Creates a new portfolio type.
        /// </summary>
        /// <param name="value">The portfolio type value.</param>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        /// <summary>
        /// Updates an existing portfolio type.
        /// </summary>
        /// <param name="id">The ID of the portfolio type.</param>
        /// <param name="value">The new value of the portfolio type.</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /// <summary>
        /// Deletes a portfolio type.
        /// </summary>
        /// <param name="id">The ID of the portfolio type.</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
