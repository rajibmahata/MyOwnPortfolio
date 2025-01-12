using Microsoft.AspNetCore.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace MyOwnPortfolio.ApiService.Utility
{
    /// <summary>
    /// Provides utility methods for generating unique numbers, hashing passwords, and generating salts.
    /// </summary>
    public class Utility
    {
        private readonly ILogger<Utility> _logger;
        private readonly IExceptionHandler _exceptionHandler;

        public Utility(ILogger<Utility> logger, IExceptionHandler exceptionHandler)
        {
            _logger = logger;
            _exceptionHandler = exceptionHandler;
        }

        /// <summary>
        /// Generates a unique number by combining the last 5 digits of the current ticks and a random 5-digit number.
        /// </summary>
        /// <returns>A unique number as a string.</returns>
        public async Task<string> GenerateUniqueNumberAsync()
        {
            try
            {
                // Get current date and time as ticks
                long ticks = DateTime.Now.Ticks;

                // Extract last 5 digits from ticks
                string lastFiveTicks = ticks.ToString()[^5..];

                // Generate a random 5-digit number
                Random random = new Random();
                int randomNumber = random.Next(10000, 99999);

                // Combine last 5 digits of ticks and random number
                string uniqueNumber = lastFiveTicks + randomNumber.ToString();

                _logger.LogInformation("Generated unique number: {UniqueNumber}", uniqueNumber);
                return uniqueNumber;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating unique number");
                await _exceptionHandler.TryHandleAsync(null, ex, CancellationToken.None);
                throw;
            }
        }

        /// <summary>
        /// Hashes a password using SHA256 with a given salt.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <param name="salt">The salt to use in the hash.</param>
        /// <returns>The hashed password as a base64 string.</returns>
        public async Task<string> HashPasswordAsync(string password, string salt)
        {
            try
            {
                using (var sha256 = SHA256.Create())
                {
                    var saltedPassword = $"{salt}{password}";
                    var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
                    string hashedPassword = Convert.ToBase64String(hash);

                    _logger.LogInformation("Password hashed successfully");
                    return hashedPassword;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error hashing password");
                await _exceptionHandler.TryHandleAsync(null, ex, CancellationToken.None);
                throw;
            }
        }

        /// <summary>
        /// Generates a cryptographic salt.
        /// </summary>
        /// <returns>A base64 string representing the generated salt.</returns>
        public async Task<string> GenerateSaltAsync()
        {
            try
            {
                using (var rng = new RNGCryptoServiceProvider())
                {
                    var saltBytes = new byte[16];
                    rng.GetBytes(saltBytes);
                    string salt = Convert.ToBase64String(saltBytes);

                    _logger.LogInformation("Generated salt: {Salt}", salt);
                    return salt;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating salt");
                await _exceptionHandler.TryHandleAsync(null, ex, CancellationToken.None);
                throw;
            }
        }
    }
}
