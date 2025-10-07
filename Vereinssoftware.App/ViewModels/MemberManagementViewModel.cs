using System.Collections.ObjectModel;
using System.Windows.Input;
using Vereinssoftware.App.Commands;
using Vereinssoftware.App.Data;
using Vereinssoftware.App.Models;

namespace Vereinssoftware.App.ViewModels
{
    public class MemberManagementViewModel : ViewModelBase
    {
        private readonly IMemberRepository _memberRepository;
        private Member? _selectedMember;
        private string _searchText = string.Empty;

        public ObservableCollection<Member> Members { get; } = new();

        public Member? SelectedMember
        {
            get => _selectedMember;
            set => SetProperty(ref _selectedMember, value);
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (SetProperty(ref _searchText, value))
                {
                    LoadMembers();
                }
            }
        }

        public ICommand AddMemberCommand { get; }
        public ICommand EditMemberCommand { get; }
        public ICommand DeleteMemberCommand { get; }
        public ICommand RefreshCommand { get; }

        public MemberManagementViewModel(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;

            AddMemberCommand = new RelayCommand(ExecuteAddMember);
            EditMemberCommand = new RelayCommand(ExecuteEditMember, _ => SelectedMember != null);
            DeleteMemberCommand = new RelayCommand(ExecuteDeleteMember, _ => SelectedMember != null);
            RefreshCommand = new RelayCommand(_ => LoadMembers());

            LoadMembers();
        }

        private void LoadMembers()
        {
            Members.Clear();
            var members = string.IsNullOrWhiteSpace(SearchText)
                ? _memberRepository.GetAll()
                : _memberRepository.Search(SearchText);

            foreach (var member in members)
            {
                Members.Add(member);
            }
        }

        private void ExecuteAddMember(object? parameter)
        {
            var newMember = new Member
            {
                FirstName = "Neues",
                LastName = "Mitglied",
                Email = "neu@example.de",
                MemberSince = DateTime.Now,
                Status = MembershipStatus.Active
            };

            _memberRepository.Add(newMember);
            LoadMembers();
        }

        private void ExecuteEditMember(object? parameter)
        {
            if (SelectedMember != null)
            {
                _memberRepository.Update(SelectedMember);
                LoadMembers();
            }
        }

        private void ExecuteDeleteMember(object? parameter)
        {
            if (SelectedMember != null)
            {
                _memberRepository.Delete(SelectedMember.Id);
                LoadMembers();
            }
        }
    }
}
