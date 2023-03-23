using Organizer.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Organizer.Services.Interfaces
{
    public interface IToDoListService
    {
        ToDoListItemModel GetToDoItemById(int id);

        IEnumerable<ToDoListItemModel> GetToDoList();

        void DeleteToDoItem(ToDoListItemModel entityToDelete);

        void UpdateToDoItem(ToDoListItemModel entityToUpdate);

        ToDoListItemModel CreateToDoItem(ToDoListItemModel entityToCreate);
    }
}
