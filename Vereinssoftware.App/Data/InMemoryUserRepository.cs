using Vereinssoftware.App.Models;
using Vereinssoftware.App.Services;

namespace Vereinssoftware.App.Data
{
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly List<User> _users = new();
        private int _nextId = 1;

        public InMemoryUserRepository()
        {
            // Add default admin user
            _users.Add(new User
            {
                Id = _nextId++,
                Username = "admin",
                PasswordHash = AuthenticationService.HashPassword("admin"),
                FirstName = "Admin",
                LastName = "User",
                Email = "admin@verein.de",
                Role = Role.Admin,
                IsActive = true
            });
        }

        public User? GetByUsername(string username)
        {
            return _users.FirstOrDefault(u => u.Username == username);
        }

        public User? GetById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _users.ToList();
        }

        public void Add(User user)
        {
            user.Id = _nextId++;
            _users.Add(user);
        }

        public void Update(User user)
        {
            var index = _users.FindIndex(u => u.Id == user.Id);
            if (index >= 0)
            {
                _users[index] = user;
            }
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            if (user != null)
            {
                _users.Remove(user);
            }
        }
    }
}
