using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Services.Repositories
{
    public class ToDoListRepository : IRepository<ToDoListItem>
    {
        public void DeleteElement(ToDoListItem entityToDelete)
        {
            using (var dbContext = new DataContext())
            {
                dbContext.ToDoListItems.Remove(entityToDelete);
                dbContext.SaveChanges();
            }
        }

        public ToDoListItem GetElementById(int id)
        {
            using (var dbContext = new DataContext())
            {
                return dbContext.ToDoListItems.FirstOrDefault(x=>x.Id == id);
            }
        }

        public IEnumerable<ToDoListItem> GetElements(Expression<ToDoListItem> expression)
        {
            using (var dbContext = new DataContext())
            {
                return dbContext.ToDoListItems.ToList();
            }
        }

        public void UpdateElement(ToDoListItem entityToUpdate)
        {
            using (var dbContext = new DataContext())
            {
                dbContext.ToDoListItems.FirstOrDefault();
                dbContext.SaveChanges();
            }
        }
    }
}
