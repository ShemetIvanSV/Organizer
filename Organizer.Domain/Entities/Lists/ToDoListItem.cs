namespace Organizer.Domain.Entities.Lists
{
    public class ToDoListItem : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool HasDone { get; set; }
    }
}
