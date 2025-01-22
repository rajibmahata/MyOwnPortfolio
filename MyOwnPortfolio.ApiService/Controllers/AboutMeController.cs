using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyOwnPortfolio.ApiService;
using MyOwnPortfolio.ApiService.Entities;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyOwnPortfolio.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutMeController : ControllerBase
    {
        private readonly MyPortfolioDbContext _context;
        public AboutMeController(MyPortfolioDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all AboutMe entries.
        /// </summary>
        /// <returns>A list of AboutMe entries.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AboutMe>>> GetAboutMes()
        {
            try
            {
                return await _context.About.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the active AboutMe entry for a specific portal.
        /// </summary>
        /// <param name="PortalID">The portal ID.</param>
        /// <returns>The active AboutMe entry.</returns>
        [HttpGet("{PortalID}")]
        public async Task<ActionResult<AboutMe>> GetAboutMeByPortalID(string PortalID)
        {
            try
            {
                var aboutMe = await _context.About.Where(x => x.MyPortalID == PortalID).ToListAsync();
                if (aboutMe == null || !aboutMe.Any(x => x.IsActive))
                {
                    return NotFound();
                }
                return Ok(aboutMe.FirstOrDefault(x => x.IsActive));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets a specific AboutMe entry by portal ID and entry ID.
        /// </summary>
        /// <param name="PortalID">The portal ID.</param>
        /// <param name="id">The entry ID.</param>
        /// <returns>The AboutMe entry.</returns>
        [HttpGet("{PortalID}/{id}")]
        public async Task<ActionResult<AboutMe>> GetAboutMe(string PortalID, string id)
        {
            try
            {
                var aboutMe = await _context.About.FindAsync(id);
                if (aboutMe == null || !aboutMe.IsActive)
                {
                    return NotFound();
                }
                return aboutMe;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Creates a new AboutMe entry.
        /// </summary>
        /// <param name="aboutMe">The AboutMe entry to create.</param>
        /// <returns>The created AboutMe entry.</returns>
        [HttpPost]
        public async Task<ActionResult<AboutMe>> PostAboutMe(AboutMe aboutMe)
        {
            try
            {
                _context.About.Add(aboutMe);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetAboutMeByPortalID), new { id = aboutMe.ID }, aboutMe);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Updates an existing AboutMe entry.
        /// </summary>
        /// <param name="id">The ID of the entry to update.</param>
        /// <param name="aboutMe">The updated AboutMe entry.</param>
        /// <returns>No content.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAboutMe(string id, AboutMe aboutMe)
        {
            if (id != aboutMe.ID)
            {
                return BadRequest();
            }

            _context.Entry(aboutMe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.About.Any(e => e.ID == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes an AboutMe entry.
        /// </summary>
        /// <param name="id">The ID of the entry to delete.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var product = await _context.About.FindAsync(id);
                if (product == null)
                {
                    return NotFound();
                }

                _context.About.Remove(product);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
