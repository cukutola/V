using System.Security.Cryptography;
using System.Text;
using Vereinssoftware.App.Data;
using Vereinssoftware.App.Models;

namespace Vereinssoftware.App.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;

        public User? CurrentUser { get; private set; }
        public bool IsAuthenticated => CurrentUser != null;

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Login(string username, string password)
        {
            var user = _userRepository.GetByUsername(username);
            if (user == null || !user.IsActive)
                return false;

            var passwordHash = HashPassword(password);
            if (user.PasswordHash != passwordHash)
                return false;

            CurrentUser = user;
            return true;
        }

        public void Logout()
        {
            CurrentUser = null;
        }

        public static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
