using Organizer.Domain.Entities.Lists;
using Organizer.Domain.Entities.Notes;
using System;
using System.Data.Entity;

namespace Organizer.DataAccess.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("OrganizerDb")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DataContext>());

            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
            if (type == null)
                throw new Exception("Do not remove, ensures static reference to System.Data.Entity.SqlServer");
        }

        public DbSet<ToDoListItem> ToDoListItems { get; set; }

        public DbSet<Note> Notes { get; set; }
    }
}
