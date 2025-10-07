using Vereinssoftware.App.Models;

namespace Vereinssoftware.App.Data
{
    public interface IMemberRepository
    {
        Member? GetById(int id);
        IEnumerable<Member> GetAll();
        void Add(Member member);
        void Update(Member member);
        void Delete(int id);
        IEnumerable<Member> Search(string searchText);
    }
}
