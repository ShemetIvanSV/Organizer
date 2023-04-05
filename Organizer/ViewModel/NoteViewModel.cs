using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Organizer.Infrastracture;
using Organizer.Mapping;
using Organizer.Models.Notes;
using Organizer.Services.Interfaces;
using Organizer.Services.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Organizer.ViewModel
{
    public class NoteViewModel : ViewModelBase
    {
        private readonly INotesService _notesService;
        private bool _wasSave = false;
        private NoteVm _selectedNote;
        private ObservableCollection<NoteVm> _notes;
        private string _filter;
        private bool _isCreate;

        public NoteViewModel(INotesService notesService)
        {
            _notesService = notesService;

            DeleteNoteCommand = new RelayCommand(DeleteNote);
            EditNoteCommand = new RelayCommand(EditNote);
            SaveNoteCommand = new RelayCommand(SaveNote);
            CreateNewNoteCommand = new RelayCommand(CreateNewNote);

            var notes = notesService.GetNotes();

            Notes = ObjectMapper.Mapper.Map<ObservableCollection<NoteVm>>(notes);
        }

        public string Filter
        {
            get => _filter;
            set 
            {
                _filter = value;
                RaisePropertyChanged();
                var notes = _notesService.GetNotes(value);
                Notes = ObjectMapper.Mapper.Map<ObservableCollection<NoteVm>>(notes);
            }
        }

        public bool WasSave
        {
            get => _wasSave;
            set { _wasSave = value; RaisePropertyChanged(); }
        }

        public ObservableCollection<NoteVm> Notes
        {
            get => _notes;
            set { _notes = value; RaisePropertyChanged(); }
        }

        public NoteVm SelectedNote
        {
            get => _selectedNote;
            set { _selectedNote = value; RaisePropertyChanged(); }
        }

        public ICommand DeleteNoteCommand { get; set; }

        public ICommand EditNoteCommand { get; set; }

        public ICommand SaveNoteCommand { get; set; }

        public ICommand CreateNewNoteCommand { get; set; }

        private void CreateNewNote()
        {
            SelectedNote = new NoteVm();
            WasSave = true;
            _isCreate = true;
        }

        private void DeleteNote()
        {
            var note = ObjectMapper.Mapper.Map<NoteModel>(SelectedNote);
            _notesService.DeleteNote(note);
            var notes = _notesService.GetNotes(Filter);
            Notes = ObjectMapper.Mapper.Map<ObservableCollection<NoteVm>>(notes);
        }

        private void EditNote()
        {
            WasSave = true;
        }

        private void SaveNote()
        {
            var note = ObjectMapper.Mapper.Map<NoteModel>(SelectedNote);

            if (_isCreate)
                _notesService.CreateNote(note);
            else
                _notesService.UpdateNote(note);



            var notes = _notesService.GetNotes(Filter);
            Notes = ObjectMapper.Mapper.Map<ObservableCollection<NoteVm>>(notes);
            if(_isCreate)
                SelectedNote = Notes.LastOrDefault();
            WasSave = false;
            _isCreate = false;
        }
    }
}
