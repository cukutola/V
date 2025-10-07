using System.Windows;
using Vereinssoftware.App.Data;
using Vereinssoftware.App.Services;
using Vereinssoftware.App.ViewModels;
using Vereinssoftware.App.Views;

namespace Vereinssoftware.App
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Initialize repositories
            var userRepository = new InMemoryUserRepository();
            var memberRepository = new InMemoryMemberRepository();
            var clubRepository = new InMemoryClubRepository();

            // Initialize services
            var authService = new AuthenticationService(userRepository);

            // Show login window
            var loginViewModel = new LoginViewModel(authService);
            var loginView = new LoginView(loginViewModel);

            if (loginView.ShowDialog() == true)
            {
                // Login successful, show main window
                var memberManagementViewModel = new MemberManagementViewModel(memberRepository);
                var userManagementViewModel = new UserManagementViewModel(userRepository);
                var clubManagementViewModel = new ClubManagementViewModel(clubRepository);

                var mainViewModel = new MainViewModel(
                    authService,
                    memberManagementViewModel,
                    userManagementViewModel,
                    clubManagementViewModel);

                var mainView = new MainView(mainViewModel);
                mainView.Show();
            }
            else
            {
                // Login failed or cancelled, shutdown application
                Shutdown();
            }
        }
    }
}
