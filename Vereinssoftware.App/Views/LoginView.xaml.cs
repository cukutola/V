using System.Windows;
using System.Windows.Controls;
using Vereinssoftware.App.ViewModels;

namespace Vereinssoftware.App.Views
{
    public partial class LoginView : Window
    {
        public LoginView(LoginViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            viewModel.LoginSuccessful += OnLoginSuccessful;
        }

        private void OnLoginSuccessful(object? sender, EventArgs e)
        {
            DialogResult = true;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel viewModel)
            {
                viewModel.Password = ((PasswordBox)sender).Password;
            }
        }
    }
}
