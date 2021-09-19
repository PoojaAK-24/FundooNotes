﻿using CommonLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface INotesRL
    {
        List<Notes> GetAllNotes(long userId);

        public bool AddNotes(NotesModel notesModel, long Id);

        public bool DeleteNotes(long id, long userId);

        public bool UpdateNotes(long id, long userId, NotesModel notesModel);
        public bool ChangeColor(long noteId, long userId, NotesModel notesModel);
        public bool IsPinned(long noteId, long userId);
        public bool IsArchive(long noteId,long userId,bool value);
        public bool IsTrash(long noteId,long userId,bool value);


    }
}
