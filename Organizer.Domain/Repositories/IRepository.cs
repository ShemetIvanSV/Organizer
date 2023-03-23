using Organizer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Organizer.Domain.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        T GetElementById(int id);

        IEnumerable<T> GetElements(Expression<Func<T, bool>> predicate = null);

        T CreateElement(T entityToCreate);

        void DeleteElement(T entityToDelete);

        void UpdateElement(T entityToUpdate);
    }
}
