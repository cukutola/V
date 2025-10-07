using Vereinssoftware.App.Models;

namespace Vereinssoftware.App.Data
{
    public class InMemoryMemberRepository : IMemberRepository
    {
        private readonly List<Member> _members = new();
        private int _nextId = 1;

        public InMemoryMemberRepository()
        {
            // Add some sample members
            _members.Add(new Member
            {
                Id = _nextId++,
                FirstName = "Max",
                LastName = "Mustermann",
                Email = "max@example.de",
                Phone = "0123-456789",
                Address = "Musterstraße 1, 12345 Musterstadt",
                DateOfBirth = new DateTime(1985, 5, 15),
                MemberSince = new DateTime(2020, 1, 1),
                Status = MembershipStatus.Active
            });

            _members.Add(new Member
            {
                Id = _nextId++,
                FirstName = "Anna",
                LastName = "Schmidt",
                Email = "anna@example.de",
                Phone = "0987-654321",
                Address = "Beispielweg 2, 54321 Beispielstadt",
                DateOfBirth = new DateTime(1990, 8, 20),
                MemberSince = new DateTime(2019, 6, 15),
                Status = MembershipStatus.Active
            });
        }

        public Member? GetById(int id)
        {
            return _members.FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Member> GetAll()
        {
            return _members.ToList();
        }

        public void Add(Member member)
        {
            member.Id = _nextId++;
            _members.Add(member);
        }

        public void Update(Member member)
        {
            var index = _members.FindIndex(m => m.Id == member.Id);
            if (index >= 0)
            {
                _members[index] = member;
            }
        }

        public void Delete(int id)
        {
            var member = GetById(id);
            if (member != null)
            {
                _members.Remove(member);
            }
        }

        public IEnumerable<Member> Search(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return GetAll();

            searchText = searchText.ToLower();
            return _members.Where(m =>
                m.FirstName.ToLower().Contains(searchText) ||
                m.LastName.ToLower().Contains(searchText) ||
                m.Email.ToLower().Contains(searchText)).ToList();
        }
    }
}
