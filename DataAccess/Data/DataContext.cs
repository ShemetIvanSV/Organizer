using Organizer.Domain.Entities.Lists;
using Organizer.Domain.Entities.Notes;
using System.Data.Entity;

namespace Organizer.DataAccess.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("AppDb")
        {

        }

        public DbSet<ToDoListItem> ToDoListItems { get; set; }

        public DbSet<Note> Notes { get; set; }
    }
}
