using GalaSoft.MvvmLight.Command;
using Organizer.Infrastracture;
using System.Windows.Input;

namespace Organizer.ViewModel
{
    public class NoteViewModel
    {
        private IFrameNavigationService _navigationService;
        public NoteViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            CreateNewNoteCommand = new RelayCommand(CreateNewNote);
        }

        public ICommand CreateNewNoteCommand { get; set; }

        private void CreateNewNote()
        {
            _navigationService.NavigateTo("NewNote");
        }
    }
}
