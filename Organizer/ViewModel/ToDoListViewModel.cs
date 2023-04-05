using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Organizer.Mapping;
using Organizer.Models.Lists;
using Organizer.Services.Interfaces;
using Organizer.Services.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Organizer.ViewModel
{
    public class ToDoListViewModel : ViewModelBase
    {
        private readonly IToDoListService _toDoListService;
        private bool _wasSave = false;
        private ToDoListItemVm _selectedItem;
        private ObservableCollection<ToDoListItemVm> _toDoList;
        private string _filter;
        private bool _isCreate;

        public ToDoListViewModel(IToDoListService toDoListService)
        {
            _toDoListService = toDoListService;

            DeleteCommand = new RelayCommand(Delete);
            EditCommand = new RelayCommand(Edit);
            SaveCommand = new RelayCommand(Save);
            CreateCommand = new RelayCommand(Create);

            var toDoList = toDoListService.GetToDoList();

            ToDoList = ObjectMapper.Mapper.Map<ObservableCollection<ToDoListItemVm>>(toDoList);
        }

        public string Filter
        {
            get => _filter;
            set
            {
                _filter = value;
                RaisePropertyChanged();
                var items = _toDoListService.GetToDoList(value);
                ToDoList = ObjectMapper.Mapper.Map<ObservableCollection<ToDoListItemVm>>(items);
            }
        }

        public bool WasSave
        {
            get => _wasSave;
            set { _wasSave = value; RaisePropertyChanged(); }
        }

        public ObservableCollection<ToDoListItemVm> ToDoList
        {
            get => _toDoList;
            set { _toDoList = value; RaisePropertyChanged(); }
        }

        public ToDoListItemVm SelectedItem
        {
            get => _selectedItem;
            set { _selectedItem = value; RaisePropertyChanged(); }
        }

        public ICommand DeleteCommand { get; set; }

        public ICommand EditCommand { get; set; }

        public ICommand SaveCommand { get; set; }

        public ICommand CreateCommand { get; set; }

        private void Create()
        {
            SelectedItem = new ToDoListItemVm();
            WasSave = true;
            _isCreate = true;
        }

        private void Delete()
        {
            var item = ObjectMapper.Mapper.Map<ToDoListItemModel>(SelectedItem);
            _toDoListService.DeleteToDoItem(item);
            var items = _toDoListService.GetToDoList(Filter);
            ToDoList = ObjectMapper.Mapper.Map<ObservableCollection<ToDoListItemVm>>(items);
        }

        private void Edit()
        {
            WasSave = true;
        }

        private void Save()
        {
            var item = ObjectMapper.Mapper.Map<ToDoListItemModel>(SelectedItem);

            if (_isCreate)
                _toDoListService.CreateToDoItem(item);
            else
                _toDoListService.UpdateToDoItem(item);

            var items = _toDoListService.GetToDoList(Filter);
            ToDoList = ObjectMapper.Mapper.Map<ObservableCollection<ToDoListItemVm>>(items);

            if (_isCreate)
                SelectedItem = ToDoList.LastOrDefault();
            WasSave = false;
            _isCreate = false;
        }
    }
}
