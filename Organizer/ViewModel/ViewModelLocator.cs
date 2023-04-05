/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Organizer"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Organizer.DataAccess.Repositories;
using Organizer.Domain.Entities.Lists;
using Organizer.Domain.Entities.Notes;
using Organizer.Domain.Repositories;
using Organizer.Infrastracture;
using Organizer.Services.Interfaces;
using Organizer.Services.Repositories;
using Organizer.Services.Services;
using System;

namespace Organizer.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SetupNavigation();

            SimpleIoc.Default.Register<IRepository<Note>, NotesRepository>();
            SimpleIoc.Default.Register<IRepository<ToDoListItem>, ToDoListRepository>();
            SimpleIoc.Default.Register<INotesService, NotesService>();
            SimpleIoc.Default.Register<IToDoListService, ToDoListService>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ToDoListViewModel>();
            SimpleIoc.Default.Register<NoteViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public NoteViewModel Note
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NoteViewModel>();
            }
        }

        public ToDoListViewModel ToDoList
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ToDoListViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }

        private static void SetupNavigation()
        {
            var navigationService = new FrameNavigationService();
            navigationService.Configure("ToDoList", new Uri("../Views/ToDoListView.xaml", UriKind.Relative));
            navigationService.Configure("Notes", new Uri("../Views/NotesView.xaml", UriKind.Relative));

            SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);
        }
    }
}