using CommonLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface INotesBL
    {
        List<Notes> GetAllNotes();

        public bool AddNotes(NotesModel notesModel, long Id);

        public bool DeleteNotes(long id, long userId);

        public bool UpdateNotes(long id, long userId, NotesModel notesModel);
      }
}
