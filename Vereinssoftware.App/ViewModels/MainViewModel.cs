using System.Windows.Input;
using Vereinssoftware.App.Commands;
using Vereinssoftware.App.Services;

namespace Vereinssoftware.App.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IAuthenticationService _authService;
        private ViewModelBase? _currentViewModel;

        public ViewModelBase? CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }

        public MemberManagementViewModel MemberManagementViewModel { get; }
        public UserManagementViewModel UserManagementViewModel { get; }
        public ClubManagementViewModel ClubManagementViewModel { get; }

        public ICommand ShowMembersCommand { get; }
        public ICommand ShowUsersCommand { get; }
        public ICommand ShowClubCommand { get; }
        public ICommand LogoutCommand { get; }

        public event EventHandler? LogoutRequested;

        public MainViewModel(
            IAuthenticationService authService,
            MemberManagementViewModel memberManagementViewModel,
            UserManagementViewModel userManagementViewModel,
            ClubManagementViewModel clubManagementViewModel)
        {
            _authService = authService;
            MemberManagementViewModel = memberManagementViewModel;
            UserManagementViewModel = userManagementViewModel;
            ClubManagementViewModel = clubManagementViewModel;

            ShowMembersCommand = new RelayCommand(_ => CurrentViewModel = MemberManagementViewModel);
            ShowUsersCommand = new RelayCommand(_ => CurrentViewModel = UserManagementViewModel);
            ShowClubCommand = new RelayCommand(_ => CurrentViewModel = ClubManagementViewModel);
            LogoutCommand = new RelayCommand(ExecuteLogout);

            CurrentViewModel = MemberManagementViewModel;
        }

        private void ExecuteLogout(object? parameter)
        {
            _authService.Logout();
            LogoutRequested?.Invoke(this, EventArgs.Empty);
        }

        public string CurrentUserName => _authService.CurrentUser?.FirstName ?? "Unbekannt";
        public string CurrentUserRole => _authService.CurrentUser?.Role.ToString() ?? "Keine";
        public bool IsAdmin => _authService.CurrentUser?.Role == Models.Role.Admin;
    }
}
