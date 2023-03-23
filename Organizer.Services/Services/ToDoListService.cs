using Organizer.Domain.Entities.Lists;
using Organizer.Domain.Repositories;
using Organizer.Services.Interfaces;
using Organizer.Services.Mapper;
using Organizer.Services.Models;
using System;
using System.Collections.Generic;

namespace Organizer.Services.Services
{
    public class ToDoListService : IToDoListService
    {
        private readonly IRepository<ToDoListItem> _repository;

        public ToDoListService(IRepository<ToDoListItem> repository)
        {
            _repository = repository;
        }

        public ToDoListItemModel CreateToDoItem(ToDoListItemModel entityToCreate)
        {
            var mappedEntity = ObjectMapper.Mapper.Map<ToDoListItem>(entityToCreate);

            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            var newItem = _repository.CreateElement(mappedEntity);

            return ObjectMapper.Mapper.Map<ToDoListItemModel>(newItem);
        }

        public void DeleteToDoItem(ToDoListItemModel entityToDelete)
        {
            var mappedEntity = ObjectMapper.Mapper.Map<ToDoListItem>(entityToDelete);

            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            _repository.DeleteElement(mappedEntity);
        }

        public ToDoListItemModel GetToDoItemById(int id)
        {
            var result = _repository.GetElementById(id);

            return ObjectMapper.Mapper.Map<ToDoListItemModel>(result);
        }

        public IEnumerable<ToDoListItemModel> GetToDoList()
        {
            var result = _repository.GetElements();
            ///TODO: правила фильтрации.
            return ObjectMapper.Mapper.Map<IEnumerable<ToDoListItemModel>>(result);
        }

        public void UpdateToDoItem(ToDoListItemModel entityToUpdate)
        {
            var mappedEntity = ObjectMapper.Mapper.Map<ToDoListItem>(entityToUpdate);

            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            _repository.UpdateElement(mappedEntity);
        }
    }
}
