using System.Collections.Generic;
using System.Linq.Expressions;

namespace Services.Repositories
{
    public interface IRepository<T>
    {
        T GetElementById(int id);

        IEnumerable<T> GetElements(Expression<T> expression);

        void DeleteElement(T entityToDelete);

        void UpdateElement(T entityToUpdate);
    }
}
