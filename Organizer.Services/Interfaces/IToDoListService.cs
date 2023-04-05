using Organizer.Services.Models;
using System.Collections.Generic;

namespace Organizer.Services.Interfaces
{
    public interface IToDoListService
    {
        ToDoListItemModel GetToDoItemById(int id);

        IEnumerable<ToDoListItemModel> GetToDoList(string filter = null);

        void DeleteToDoItem(ToDoListItemModel entityToDelete);

        void UpdateToDoItem(ToDoListItemModel entityToUpdate);

        ToDoListItemModel CreateToDoItem(ToDoListItemModel entityToCreate);
    }
}
