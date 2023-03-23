using Organizer.DataAccess.Data;
using Organizer.Domain.Entities.Lists;
using Organizer.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Organizer.DataAccess.Repositories
{
    public class ToDoListRepository : IRepository<ToDoListItem>
    {
        public ToDoListItem CreateElement(ToDoListItem entityToCreate)
        {
            using (var dbContext = new DataContext())
            {
                dbContext.ToDoListItems.Add(entityToCreate);
                var createdEntityId = dbContext.SaveChanges();
                return dbContext.ToDoListItems.FirstOrDefault(x => x.Id == createdEntityId);
            }
        }

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

        public IEnumerable<ToDoListItem> GetElements(Expression<Func<ToDoListItem, bool>> predicate = null)
        {
            using (var dbContext = new DataContext())
            {
                return dbContext.ToDoListItems.Where(predicate).ToList();
            }
        }

        public void UpdateElement(ToDoListItem entityToUpdate)
        {
            using (var dbContext = new DataContext())
            {
                dbContext.Entry(entityToUpdate).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }
    }
}
