using System.Windows;
using System.Windows.Input;
using Vereinssoftware.App.Commands;
using Vereinssoftware.App.Services;

namespace Vereinssoftware.App.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IAuthenticationService _authService;
        private string _username = string.Empty;
        private string _password = string.Empty;
        private string _errorMessage = string.Empty;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        public ICommand LoginCommand { get; }

        public event EventHandler? LoginSuccessful;

        public LoginViewModel(IAuthenticationService authService)
        {
            _authService = authService;
            LoginCommand = new RelayCommand(ExecuteLogin, CanExecuteLogin);
        }

        private bool CanExecuteLogin(object? parameter)
        {
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        }

        private void ExecuteLogin(object? parameter)
        {
            ErrorMessage = string.Empty;

            if (_authService.Login(Username, Password))
            {
                LoginSuccessful?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                ErrorMessage = "Ungültiger Benutzername oder Passwort";
                Password = string.Empty;
            }
        }
    }
}
