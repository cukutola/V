using System.Collections.ObjectModel;
using System.Windows.Input;
using Vereinssoftware.App.Commands;
using Vereinssoftware.App.Data;
using Vereinssoftware.App.Models;
using Vereinssoftware.App.Services;

namespace Vereinssoftware.App.ViewModels
{
    public class UserManagementViewModel : ViewModelBase
    {
        private readonly IUserRepository _userRepository;
        private User? _selectedUser;

        public ObservableCollection<User> Users { get; } = new();

        public User? SelectedUser
        {
            get => _selectedUser;
            set => SetProperty(ref _selectedUser, value);
        }

        public ICommand AddUserCommand { get; }
        public ICommand DeleteUserCommand { get; }
        public ICommand RefreshCommand { get; }

        public UserManagementViewModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            AddUserCommand = new RelayCommand(ExecuteAddUser);
            DeleteUserCommand = new RelayCommand(ExecuteDeleteUser, _ => SelectedUser != null);
            RefreshCommand = new RelayCommand(_ => LoadUsers());

            LoadUsers();
        }

        private void LoadUsers()
        {
            Users.Clear();
            foreach (var user in _userRepository.GetAll())
            {
                Users.Add(user);
            }
        }

        private void ExecuteAddUser(object? parameter)
        {
            var newUser = new User
            {
                Username = "neuer.benutzer",
                PasswordHash = AuthenticationService.HashPassword("passwort"),
                FirstName = "Neuer",
                LastName = "Benutzer",
                Email = "neu@verein.de",
                Role = Role.Member,
                IsActive = true
            };

            _userRepository.Add(newUser);
            LoadUsers();
        }

        private void ExecuteDeleteUser(object? parameter)
        {
            if (SelectedUser != null && SelectedUser.Id != 1) // Don't delete admin
            {
                _userRepository.Delete(SelectedUser.Id);
                LoadUsers();
            }
        }
    }
}
