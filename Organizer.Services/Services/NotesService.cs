using Organizer.Domain.Entities.Notes;
using Organizer.Domain.Repositories;
using Organizer.Services.Interfaces;
using Organizer.Services.Mapper;
using Organizer.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.Services.Services
{
    public class NotesService : INotesService
    {
        private readonly IRepository<Note> _repository;

        public NotesService(IRepository<Note> repository)
        {
            _repository = repository;
        }

        public NoteModel CreateNote(NoteModel noteToCreate)
        {
            var mappedEntity = ObjectMapper.Mapper.Map<Note>(noteToCreate);

            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            var newItem = _repository.CreateElement(mappedEntity);

            return ObjectMapper.Mapper.Map<NoteModel>(newItem);
        }

        public void DeleteNote(NoteModel noteToDelete)
        {
            var mappedEntity = ObjectMapper.Mapper.Map<Note>(noteToDelete);

            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            _repository.DeleteElement(mappedEntity);
        }

        public NoteModel GetNoteById(int id)
        {
            var result = _repository.GetElementById(id);

            return ObjectMapper.Mapper.Map<NoteModel>(result);
        }

        public IEnumerable<NoteModel> GetNotes(string filter = null)
        {
            IEnumerable<Note> notes;

            if (string.IsNullOrEmpty(filter))
                notes = _repository.GetElements();
            else
                notes = _repository.GetElements((note) => note.Name.Contains(filter));

            return ObjectMapper.Mapper.Map<IEnumerable<NoteModel>>(notes);
        }

        public void UpdateNote(NoteModel noteToUpdate)
        {
            var mappedEntity = ObjectMapper.Mapper.Map<Note>(noteToUpdate);

            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            _repository.UpdateElement(mappedEntity);
        }
    }
}
