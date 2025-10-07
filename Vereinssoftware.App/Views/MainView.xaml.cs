using System.Windows;
using Vereinssoftware.App.ViewModels;

namespace Vereinssoftware.App.Views
{
    public partial class MainView : Window
    {
        public MainView(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            viewModel.LogoutRequested += OnLogoutRequested;
        }

        private void OnLogoutRequested(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
