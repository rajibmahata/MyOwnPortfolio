using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyOwnPortfolio.ApiService.Entities;
using MyOwnPortfolio.ApiService.Entities.RequestModel;
using MyOwnPortfolio.ApiService.Entities.SwaggerExamples;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace MyOwnPortfolio.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly MyPortfolioDbContext _context;
        public AuthController(MyPortfolioDbContext context)
        {
            _context = context;
        }


        [HttpPost("login")]
        [SwaggerOperation(
        Summary = "Auth login",
        Description = "User Login"
    )]
        [SwaggerRequestExample(typeof(LoginRequestExample), typeof(LoginRequestExample))]
        [SwaggerResponse(200, "Success", typeof(IEnumerable<MyPortal>))]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel request)
        {
            try
            {
                var user = await _context.MyPortals
                       .SingleOrDefaultAsync(u => u.Username == request.Username && u.IsActive==true);

                if (user == null)
                {
                    return Unauthorized("Invalid username or password.");
                }

                // Hash the entered password with the stored salt
                var hashedPassword = Utility.Utility.HashPassword(request.Password, user.Passwordsalt);

                if (hashedPassword != user.Passwordhash)
                {
                    return Unauthorized("Invalid username or password.");
                }

                // Return success (typically, you'd generate and return a JWT here)
                return Ok(user);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register")]

        [SwaggerOperation(
        Summary = "Auth Register",
        Description = "User Registration"
    )]
        [SwaggerRequestExample(typeof(RegistrationRequestExample), typeof(RegistrationRequestExample))]
        [SwaggerResponse(200, "Success", typeof(MyPortal))]
        public async Task<IActionResult> Register([FromBody] MyPortalRequest request)
        {
            try
            {
                // Check if the username is already taken
                var existingUser = await _context.MyPortals
                    .SingleOrDefaultAsync(u => u.Username == request.Username);

                if (existingUser != null)
                {
                    return BadRequest("Username is already taken.");
                }

                // Generate a salt
                var salt = Utility.Utility.GenerateSalt();

                // Hash the password with the salt
                var hashedPassword = Utility.Utility.HashPassword(request.Password, salt);

                // Create the new user object
                var newUser = new MyPortal
                {
                    ID = Utility.Utility.GenerateUniqueNumber(),
                    Username = request.Username,
                    Passwordhash = hashedPassword,
                    Passwordsalt = salt,
                    IsActive=true

                };

                // Save the user to the database
                _context.MyPortals.Add(newUser);
                await _context.SaveChangesAsync();

                return Ok(newUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
