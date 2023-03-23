using Organizer.DataAccess.Data;
using Organizer.Domain.Entities.Notes;
using Organizer.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Organizer.Services.Repositories
{
    public class NotesRepository : IRepository<Note>
    {
        public Note CreateElement(Note entityToCreate)
        {
            using (var dbContext = new DataContext())
            {
                dbContext.Notes.Add(entityToCreate);
                var createdEntityId = dbContext.SaveChanges();
                return dbContext.Notes.FirstOrDefault(x => x.Id == createdEntityId);
            }
        }

        public void DeleteElement(Note entityToDelete)
        {
            using (var dbContext = new DataContext())
            {
                dbContext.Notes.Remove(entityToDelete);
                dbContext.SaveChanges();
            }
        }

        public Note GetElementById(int id)
        {
            using (var dbContext = new DataContext())
            {
                return dbContext.Notes.FirstOrDefault(x => x.Id == id);
            }
        }

        public IEnumerable<Note> GetElements(Expression<Func<Note, bool>> predicate = null)
        {
            using (var dbContext = new DataContext())
            {
                return dbContext.Notes.Where(predicate).ToList();
            }
        }

        public void UpdateElement(Note entityToUpdate)
        {
            using (var dbContext = new DataContext())
            {
                dbContext.Entry(entityToUpdate).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }
    }
}
