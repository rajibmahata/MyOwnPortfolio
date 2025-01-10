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
        // GET: api/<AboutMeController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AboutMe>>> GetAboutMes()
        {
            try
            {
                return await _context.About.ToListAsync();
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        // GET api/<AboutMeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AboutMe>> GetAboutMe(int id)
        {
            try
            {
                var aboutMe = await _context.About.FindAsync(id);
                if (aboutMe == null)
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

        // POST api/<AboutMeController>
        [HttpPost]
        public async Task<ActionResult<AboutMe>> PostAboutMe(AboutMe aboutMe)
        {
            try
            {
                _context.About.Add(aboutMe);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetAboutMe), new { id = aboutMe.ID }, aboutMe);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        // PUT api/<AboutMeController>/5
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

        // DELETE api/<AboutMeController>/5
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
