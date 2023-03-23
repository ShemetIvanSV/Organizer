namespace Services.Repositories
{
    public class NotesRepository : IRepository<Note>
    {
        public void DeleteElement(Note entityToDelete)
        {
            throw new System.NotImplementedException();
        }

        public Note GetElementById(int id)
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<Note> GetElements(System.Linq.Expressions.Expression<Note> expression)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateElement(Note entityToUpdate)
        {
            throw new System.NotImplementedException();
        }
    }
}
