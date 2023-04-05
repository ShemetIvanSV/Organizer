using Organizer.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Organizer.Services.Interfaces
{
    public interface INotesService
    {
        NoteModel GetNoteById(int id);

        IEnumerable<NoteModel> GetNotes(string filter = null);

        void DeleteNote(NoteModel noteToDelete);

        void UpdateNote(NoteModel noteToUpdate);

        NoteModel CreateNote(NoteModel noteToCreate);
    }
}
