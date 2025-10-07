using Vereinssoftware.App.Models;

namespace Vereinssoftware.App.Data
{
    public class InMemoryClubRepository : IClubRepository
    {
        private Club _club;

        public InMemoryClubRepository()
        {
            _club = new Club
            {
                Id = 1,
                Name = "Muster Verein e.V.",
                Description = "Ein Beispielverein für die Vereinssoftware",
                Address = "Vereinsstraße 123, 12345 Vereinsstadt",
                Phone = "0123-456789",
                Email = "info@musterverein.de",
                Website = "www.musterverein.de",
                FoundedDate = new DateTime(2000, 1, 1),
                MemberCount = 0
            };
        }

        public Club? GetById(int id)
        {
            return id == _club.Id ? _club : null;
        }

        public Club? GetCurrent()
        {
            return _club;
        }

        public void Update(Club club)
        {
            _club = club;
        }
    }
}
