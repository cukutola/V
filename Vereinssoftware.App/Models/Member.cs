namespace Vereinssoftware.App.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public DateTime MemberSince { get; set; } = DateTime.Now;
        public MembershipStatus Status { get; set; } = MembershipStatus.Active;
        public string Notes { get; set; } = string.Empty;
    }

    public enum MembershipStatus
    {
        Active,
        Inactive,
        Suspended
    }
}
