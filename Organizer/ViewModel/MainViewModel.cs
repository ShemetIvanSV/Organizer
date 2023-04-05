using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Organizer.Infrastracture;
using System.Windows.Input;

namespace Organizer.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            OpenNotesCommand = new RelayCommand(OpenNotes);
            OpenToDoListCommand = new RelayCommand(OpenToDoList);
        }

        public ICommand OpenNotesCommand { get; set; }
        public ICommand OpenToDoListCommand { get; set; }

        private void OpenNotes()
        {
            _navigationService.NavigateTo("Notes");
        }

        private void OpenToDoList()
        {
            _navigationService.NavigateTo("ToDoList");
        }
    }
}