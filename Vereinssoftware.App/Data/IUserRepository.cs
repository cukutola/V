using Vereinssoftware.App.Models;

namespace Vereinssoftware.App.Data
{
    public interface IUserRepository
    {
        User? GetByUsername(string username);
        User? GetById(int id);
        IEnumerable<User> GetAll();
        void Add(User user);
        void Update(User user);
        void Delete(int id);
    }
}
