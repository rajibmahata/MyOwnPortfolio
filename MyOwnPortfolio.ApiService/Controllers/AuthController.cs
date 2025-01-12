using AutoMapper;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyOwnPortfolio.ApiService.Entities;
using MyOwnPortfolio.ApiService.Entities.RequestModel;
using MyOwnPortfolio.ApiService.Enum;
using MyOwnPortfolio.ApiService.Models;
using MyOwnPortfolio.ApiService.Models.RequestResponseModel;
using MyOwnPortfolio.ApiService.Models.SwaggerExamples;
using MyOwnPortfolio.ApiService.Utility;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace MyOwnPortfolio.ApiService.Controllers
{
    /// <summary>
    /// Controller for handling authentication related actions.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly MyPortfolioDbContext _context;
        private readonly ILogger<AuthController> _logger;
        private readonly IExceptionHandler _exceptionHandler;
        private readonly IMapper _mapper;
        private readonly Utility.Utility _utility;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <param name="logger">The logger instance.</param>
        /// <param name="exceptionHandler">The exception handler instance.</param>
        /// <param name="mapper">The mapper instance.</param>
        /// <param name="utility">The utility instance.</param>
        public AuthController(MyPortfolioDbContext context, ILogger<AuthController> logger, IExceptionHandler exceptionHandler, IMapper mapper, Utility.Utility utility)
        {
            _context = context;
            _logger = logger;
            _exceptionHandler = exceptionHandler;
            _mapper = mapper;
            _utility = utility;

            // Add the missing type map configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AboutMe, AboutMeUIModel>();
            });

            _mapper = config.CreateMapper();
        }

        /// <summary>
        /// User Login
        /// </summary>
        /// <param name="request">The login request model containing username and password.</param>
        /// <returns>Returns an IActionResult indicating the result of the login attempt.</returns>
        [HttpPost("login")]
        [SwaggerOperation(Summary = "Login", Description = "User Login")]
        [SwaggerRequestExample(typeof(LoginRequestExample), typeof(LoginRequestExample))]
        [SwaggerResponse(200, "Success", typeof(LoginResponseModel))]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel request)
        {
            _logger.LogInformation("Login attempt for user: {Username}", request.Username);
            try
            {
                var user = await _context.MyPortals.Include(order => order.AboutMe)
                       .SingleOrDefaultAsync(u => u.Username == request.Username && u.IsActive == true);

                if (user == null)
                {
                    _logger.LogWarning("Login failed for user: {Username} - Invalid username or password.", request.Username);
                    return Unauthorized("Invalid username or password.");
                }

                // Hash the entered password with the stored salt
                var hashedPassword = await _utility.HashPasswordAsync(request.Password, user.Passwordsalt);

                if (hashedPassword != user.Passwordhash)
                {
                    _logger.LogWarning("Login failed for user: {Username} - Invalid username or password.", request.Username);
                    return Unauthorized("Invalid username or password.");
                }
                else
                {
                   
                    LoginResponseModel loginResponse = new LoginResponseModel()
                    {
                        ID = user.ID,
                        Username = user.Username,
                        IsActive = user.IsActive,
                        CreatedDate = user.CreatedDate,
                        ModifiedDate = user.ModifiedDate,
                        AboutMe = _mapper.Map<AboutMeUIModel>(user.AboutMe),
                        StatusCode = (int)MyOwnPortfolioStatusEnum.Success,
                        StatusMessage = MyOwnPortfolioStatusEnum.Success.GetDescription()
                    };

                    _logger.LogInformation("Login successful for user: {Username}", request.Username);
                    // Return success (typically, you'd generate and return a JWT here)
                    return Ok(loginResponse);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during login for user: {Username}", request.Username);
                await _exceptionHandler.TryHandleAsync(HttpContext, ex, CancellationToken.None);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// User Registration
        /// </summary>
        /// <param name="request">The registration request model containing user details.</param>
        /// <returns>Returns an IActionResult indicating the result of the registration attempt.</returns>
        [HttpPost("register")]
        [SwaggerOperation(Summary = "Auth Register", Description = "User Registration")]
        [SwaggerRequestExample(typeof(RegistrationRequestExample), typeof(RegistrationRequestExample))]
        [SwaggerResponse(200, "Success", typeof(RegistrationResponseModel))]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestModel request)
        {
            _logger.LogInformation("Registration attempt for user: {Username}", request.Username);
            try
            {
                // Check if the username is already taken
                var existingUser = await _context.MyPortals
                    .SingleOrDefaultAsync(u => u.Username == request.Username);

                if (existingUser != null)
                {
                    _logger.LogWarning("Registration failed for user: {Username} - Username is already taken.", request.Username);
                    return BadRequest("Username is already taken.");
                }

                // Generate a salt
                var salt = await _utility.GenerateSaltAsync();

                // Hash the password with the salt
                var hashedPassword = await _utility.HashPasswordAsync(request.Password, salt);
                string portfolioID = await _utility.GenerateUniqueNumberAsync();
                string aboutMeID = await _utility.GenerateUniqueNumberAsync();
                // Create the new user object
                var myNewPortfolio = new MyPortal
                {
                    ID = portfolioID,
                    Username = request.Username,
                    Passwordhash = hashedPassword,
                    Passwordsalt = salt,
                    IsActive = true,
                    AboutMe = new AboutMe
                    {
                        ID = aboutMeID,
                        MyPortalID = portfolioID,
                        Name = request.Name,
                        Email = request.Email,
                        ContactNumber = request.ContactNumber
                    }
                };

                // Save the user to the database
                _context.MyPortals.Add(myNewPortfolio);

                await _context.SaveChangesAsync();

                // Fix for CS9035: Required member 'RegistrationResponseModel.AboutMe' must be set in the object initializer or attribute constructor.
                // Fix for IDE0090: 'new' expression can be simplified

                // Inside the Register method, update the response initialization
                RegistrationResponseModel response = new()
                {
                    ID = myNewPortfolio.ID,
                    Username = myNewPortfolio.Username,
                    IsActive = myNewPortfolio.IsActive,
                    CreatedDate = myNewPortfolio.CreatedDate,
                    ModifiedDate = myNewPortfolio.ModifiedDate,
                    StatusCode = (int)MyOwnPortfolioStatusEnum.Success,
                    StatusMessage = MyOwnPortfolioStatusEnum.Success.GetDescription(),
                    AboutMe=new AboutMeUIModel
                    {
                        Name = request.Name,
                        Email = request.Email,
                        ContactNumber = request.ContactNumber
                    }
                    //AboutMe = _mapper.Map<AboutMeUIModel>(myNewPortfolio.AboutMe) // Set the required AboutMe property
                };

                _logger.LogInformation("Registration successful for user: {Username}", request.Username);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during registration for user: {Username}", request.Username);
                await _exceptionHandler.TryHandleAsync(HttpContext, ex, CancellationToken.None);
                return BadRequest(ex.Message);
            }
        }
    }
}
