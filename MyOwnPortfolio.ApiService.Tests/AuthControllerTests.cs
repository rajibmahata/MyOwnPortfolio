using AutoMapper;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using MyOwnPortfolio.ApiService.Controllers;
using MyOwnPortfolio.ApiService.Entities.RequestModel;
using MyOwnPortfolio.ApiService.Entities;
using MyOwnPortfolio.ApiService.Models.RequestResponseModel;
using MyOwnPortfolio.ApiService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MyOwnPortfolio.ApiService.Tests
{
    [TestClass]
    public class AuthControllerTests
    {
        private Mock<MyPortfolioDbContext> _mockContext;
        private Mock<ILogger<AuthController>> _mockLogger;
        private Mock<IExceptionHandler> _mockExceptionHandler;
        private Mock<IMapper> _mockMapper;
        private Mock<Utility.Utility> _mockUtility;
        private AuthController _authController;

        private Mock<ILogger<Utility.Utility>> _mockUtilityLogger;
        private Utility.Utility _utility;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<MyPortfolioDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var context = new MyPortfolioDbContext(options);

            _mockContext = new Mock<MyPortfolioDbContext>();
            _mockLogger = new Mock<ILogger<AuthController>>();
            _mockExceptionHandler = new Mock<IExceptionHandler>();
            _mockMapper = new Mock<IMapper>();
            _mockUtility = new Mock<Utility.Utility>();

            _mockUtilityLogger = new Mock<ILogger<Utility.Utility>>();
            _mockExceptionHandler = new Mock<IExceptionHandler>();
            _utility = new Utility.Utility(_mockUtilityLogger.Object, _mockExceptionHandler.Object);

            _authController = new AuthController(
               context,
                _mockLogger.Object,
                _mockExceptionHandler.Object,
                _mockMapper.Object,
                _utility
            );
        }

        [TestMethod]
        public async Task Login_ValidCredentials_ReturnsOkResult()
        {
            // Arrange
            var username = "rajibmahata";
            var password = "12345678";
            var request = new LoginRequestModel { Username = username, Password = password };

            var user = new MyPortal
            {
                Username = username,
                Passwordhash = "hashedpassword",
                Passwordsalt = "salt",
                IsActive = true,
                AboutMe = new AboutMe { Name = "Rajib Mahata" }
            };

            _mockContext.Setup(x => x.MyPortals.SingleOrDefaultAsync(
                It.IsAny<Expression<Func<MyPortal, bool>>>(),
                default))
                .ReturnsAsync(user);

            _mockUtility.Setup(x => x.HashPasswordAsync(password, user.Passwordsalt))
                .ReturnsAsync("hashedpassword");

            _mockMapper.Setup(m => m.Map<AboutMeUIModel>(user.AboutMe))
                .Returns(new AboutMeUIModel { Name = "Rajib Mahata", Email= "rajibmahata143@outlook.com", ContactNumber= "8420249020" });

            // Act
            var result = await _authController.Login(request);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var response = okResult.Value as LoginResponseModel;
            Assert.IsNotNull(response);
            Assert.AreEqual(username, response.Username);
        }

        [TestMethod]
        public async Task Login_InvalidCredentials_ReturnsUnauthorizedResult()
        {
            // Arrange
            var username = "testuser";
            var password = "wrongpassword";
            var request = new LoginRequestModel { Username = username, Password = password };

            var user = new MyPortal
            {
                Username = username,
                Passwordhash = "hashedpassword",
                Passwordsalt = "salt",
                IsActive = true
            };

            _mockContext.Setup(x => x.MyPortals.SingleOrDefaultAsync(
                It.IsAny<Expression<Func<MyPortal, bool>>>(),
                default))
                .ReturnsAsync(user);

            _mockUtility.Setup(x => x.HashPasswordAsync(password, user.Passwordsalt))
                .ReturnsAsync("wronghashedpassword");

            // Act
            var result = await _authController.Login(request);

            // Assert
            Assert.IsInstanceOfType(result, typeof(UnauthorizedObjectResult));
        }
        [TestMethod]
        public async Task Register_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var request = new RegistrationRequestModel
            {
                Username = "rajibmahata",
                Password = "12345678",
                ContactNumber = "8420249020",
                Email = "rajibmahata143@outlook.com",
                Name = "Rajib Mahata"
            };

            _mockContext.Setup(x => x.MyPortals.SingleOrDefaultAsync(
                It.IsAny<Expression<Func<MyPortal, bool>>>(),
                default))
                .ReturnsAsync((MyPortal)null); // No existing user

            _mockUtility.Setup(x => x.GenerateSaltAsync())
                .ReturnsAsync("salt");
            _mockUtility.Setup(x => x.HashPasswordAsync(request.Password, "salt"))
                .ReturnsAsync("hashedpassword");
            _mockUtility.Setup(x => x.GenerateUniqueNumberAsync())
                .ReturnsAsync("uniqueID");

            _mockMapper.Setup(m => m.Map<AboutMeUIModel>(It.IsAny<AboutMe>()))
                .Returns(new AboutMeUIModel { Name = "Rajib Mahata", Email = "rajibmahata143@outlook.com", ContactNumber = "8420249020" });

            // Act
            var result = await _authController.Register(request);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var response = okResult.Value as RegistrationResponseModel;
            Assert.IsNotNull(response);
            Assert.AreEqual(request.Username, response.Username);
        }

        [TestMethod]
        public async Task Register_UsernameAlreadyTaken_ReturnsBadRequest()
        {
            // Arrange
            var request = new RegistrationRequestModel { Username = "existinguser", Password = "password" ,
                Name = "newuser",
                Email = "testuser@example.com",
                ContactNumber = "1234567890"
            };

            var existingUser = new MyPortal { Username = "existinguser" };

            _mockContext.Setup(x => x.MyPortals.SingleOrDefaultAsync(
                It.IsAny<Expression<Func<MyPortal, bool>>>(),
                default))
                .ReturnsAsync(existingUser);

            // Act
            var result = await _authController.Register(request);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            var badRequestResult = result as BadRequestObjectResult;
            Assert.IsNotNull(badRequestResult);
            Assert.AreEqual("Username is already taken.", badRequestResult.Value);
        }

    }

}
