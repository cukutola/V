using Vereinssoftware.App.Models;

namespace Vereinssoftware.App.Data
{
    public interface IClubRepository
    {
        Club? GetById(int id);
        Club? GetCurrent();
        void Update(Club club);
    }
}
