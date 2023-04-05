using GalaSoft.MvvmLight;

namespace Organizer.Models.Notes
{
    public class NoteVm : ViewModelBase
    {
        private int _id;
        private string _name;
        private string _description;

        public int Id
        {
            get => _id;
            set { _id = value; RaisePropertyChanged(); }
        }

        public string Name
        {
            get => _name;
            set { _name = value; RaisePropertyChanged(); }
        }

        public string Description
        {
            get => _description;
            set { _description = value; RaisePropertyChanged(); }
        }
    }
}
