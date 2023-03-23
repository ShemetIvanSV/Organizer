namespace Organizer.Services.Models
{
    public class ToDoListItemModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool HasDone { get; set; }
    }
}
