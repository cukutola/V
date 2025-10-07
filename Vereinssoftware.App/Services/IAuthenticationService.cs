using Vereinssoftware.App.Models;

namespace Vereinssoftware.App.Services
{
    public interface IAuthenticationService
    {
        User? CurrentUser { get; }
        bool Login(string username, string password);
        void Logout();
        bool IsAuthenticated { get; }
    }
}
