using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyOwnPortfolio.ApiService.Entities;
using MyOwnPortfolio.ApiService.Models.RequestResponseModels;
using MyOwnPortfolio.ApiService.Models.SwaggerExamples;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyOwnPortfolio.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyPortalController : ControllerBase
    {
        private readonly MyPortfolioDbContext _context;
        public MyPortalController(MyPortfolioDbContext context)
        {
            _context = context;
        }


        // GET: api/<AboutMeController>
        [HttpGet]
        [SwaggerOperation(
        Summary = "Get My Portal",
        Description = "Retrieve a list of all portal available in the database."
    )]
        [SwaggerResponse(200, "Success", typeof(IEnumerable<MyPortal>))]
        public async Task<ActionResult<IEnumerable<MyPortal>>> GetMyPortals()
        {
            try
            {
                return await _context.MyPortals.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET api/<AboutMeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MyPortal>> GetMyPortal(long id)
        {
            try
            {
                var myPortal = await _context.MyPortals.FindAsync(id);
                if (myPortal == null)
                {
                    return NotFound();
                }
                return myPortal;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // POST api/<AboutMeController>
        [HttpPost]
        [SwaggerOperation(
        Summary = "Create a new product",
        Description = "Add a new product to the database."
    )]
        [SwaggerRequestExample(typeof(MyPortalExample), typeof(MyPortalExample))]
        [SwaggerResponse(201, "Product created", typeof(MyPortal))]
        public async Task<ActionResult<MyPortal>> PostMyPortal(MyPortalRequest myportalRequest)
        {
            try
            {
                MyPortal myPortal = new MyPortal()
                {
                    //ID = Utility.Utility.GenerateUniqueNumber(),
                    Username = myportalRequest.Username,
                    Passwordhash = myportalRequest.Password,
                   
                };


                _context.MyPortals.Add(myPortal);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetMyPortal), new { id = myPortal.ID }, myPortal);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        // PUT api/<AboutMeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMyPortal(string id, MyPortal myPortal)
        {
            if (id != myPortal.ID)
            {
                return BadRequest();
            }

            _context.Entry(myPortal).State = EntityState.Modified;

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
        public async Task<IActionResult> DeleteMyPortal(int id)
        {
            try
            {
                var myPortal = await _context.MyPortals.FindAsync(id);
                if (myPortal == null)
                {
                    return NotFound();
                }

                _context.MyPortals.Remove(myPortal);
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
