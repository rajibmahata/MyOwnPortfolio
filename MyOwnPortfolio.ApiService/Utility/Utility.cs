using System.Security.Cryptography;
using System.Text;

namespace MyOwnPortfolio.ApiService.Utility
{
    public static class Utility
    {
        public static string GenerateUniqueNumber()
        {
            // Get current date and time as ticks
            long ticks = DateTime.Now.Ticks;

            // Extract last 5 digits from ticks
            string ticksString = ticks.ToString();
            string lastFiveTicks = ticksString.Substring(Math.Max(0, ticksString.Length - 5));

            // Generate a random 5-digit number
            Random random = new Random();
            int randomNumber = random.Next(10000, 99999);

            // Combine last 5 digits of ticks and random number
            string uniqueNumber = lastFiveTicks + randomNumber.ToString();

            return uniqueNumber;
        }
        public static string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = $"{salt}{password}";
                var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
                return Convert.ToBase64String(hash);
            }
        }

        public static string GenerateSalt()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var saltBytes = new byte[16];
                rng.GetBytes(saltBytes);
                return Convert.ToBase64String(saltBytes);
            }
        }
    }
}
