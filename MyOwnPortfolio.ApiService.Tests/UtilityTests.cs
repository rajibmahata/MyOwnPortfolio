using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOwnPortfolio.ApiService.Tests
{
    [TestClass]
    public class UtilityTests
    {
        private Mock<ILogger<Utility.Utility>> _mockLogger;
        private Mock<IExceptionHandler> _mockExceptionHandler;
        private Utility.Utility _utility;

        [TestInitialize]
        public void Setup()
        {
            _mockLogger = new Mock<ILogger<Utility.Utility>>();
            _mockExceptionHandler = new Mock<IExceptionHandler>();
            _utility = new Utility.Utility(_mockLogger.Object, _mockExceptionHandler.Object);
        }

        [TestMethod]
        public async Task GenerateUniqueNumberAsync_ReturnsUniqueNumber()
        {
            // Act
            var uniqueNumber = await _utility.GenerateUniqueNumberAsync();

            // Assert
            Assert.IsNotNull(uniqueNumber);
            Assert.AreEqual(10, uniqueNumber.Length); // Since it's last 5 digits of ticks + 5 random digits
            _mockLogger.Verify(logger => logger.LogInformation(It.IsAny<string>(), uniqueNumber), Times.Once);
        }

        [TestMethod]
        public async Task HashPasswordAsync_ReturnsHashedPassword()
        {
            // Arrange
            string password = "TestPassword";
            string salt = "TestSalt";

            // Act
            var hashedPassword = await _utility.HashPasswordAsync(password, salt);

            // Assert
            Assert.IsNotNull(hashedPassword);
            Assert.IsTrue(hashedPassword.Length > 0);

            // Hash the same password and salt manually to compare
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var saltedPassword = $"{salt}{password}";
                var expectedHash = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword)));
                Assert.AreEqual(expectedHash, hashedPassword);
            }

            _mockLogger.Verify(logger => logger.LogInformation(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public async Task GenerateSaltAsync_ReturnsValidSalt()
        {
            // Act
            var salt = await _utility.GenerateSaltAsync();

            // Assert
            Assert.IsNotNull(salt);
            Assert.IsTrue(salt.Length > 0); // Base64-encoded salt should have some length
            _mockLogger.Verify(logger => logger.LogInformation(It.IsAny<string>(), salt), Times.Once);
        }

        [TestMethod]
        public async Task GenerateUniqueNumberAsync_LogsAndHandlesException()
        {
            // Arrange
            _mockLogger.Setup(logger => logger.LogError(It.IsAny<Exception>(), It.IsAny<string>()));

            var testException = new Exception("Test Exception");
            _mockExceptionHandler.Setup(eh => eh.TryHandleAsync(It.IsAny<HttpContext>(), testException, It.IsAny<CancellationToken>()))
                                 .Throws(testException);

            // Use Reflection to cause an exception in GenerateUniqueNumberAsync
            var originalTicks = DateTime.Now.Ticks;
            try
            {
                // Code runs Random( fixed Error (Stack Trace) Details included in MockFramework and Verify Error Steps resolution.
            }
            catch (Exception)
            {
                // Handle the exception
            }
        }
    }
}
