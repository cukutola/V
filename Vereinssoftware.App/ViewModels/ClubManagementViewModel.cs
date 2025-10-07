using System.Windows.Input;
using Vereinssoftware.App.Commands;
using Vereinssoftware.App.Data;
using Vereinssoftware.App.Models;

namespace Vereinssoftware.App.ViewModels
{
    public class ClubManagementViewModel : ViewModelBase
    {
        private readonly IClubRepository _clubRepository;
        private Club? _club;

        public Club? Club
        {
            get => _club;
            set => SetProperty(ref _club, value);
        }

        public ICommand SaveCommand { get; }
        public ICommand RefreshCommand { get; }

        public ClubManagementViewModel(IClubRepository clubRepository)
        {
            _clubRepository = clubRepository;

            SaveCommand = new RelayCommand(ExecuteSave, _ => Club != null);
            RefreshCommand = new RelayCommand(_ => LoadClub());

            LoadClub();
        }

        private void LoadClub()
        {
            Club = _clubRepository.GetCurrent();
        }

        private void ExecuteSave(object? parameter)
        {
            if (Club != null)
            {
                _clubRepository.Update(Club);
            }
        }
    }
}
