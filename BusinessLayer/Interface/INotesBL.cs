using CommonLayer;
using Microsoft.AspNetCore.Http;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface INotesBL
    {
        List<Notes> GetAllNotes(long userId);

        public bool AddNotes(NotesModel notesModel, long Id);
        public bool UpdateNotes(long id, long userId, NotesModel notesModel);

        public bool DeleteNotes(long id, long userId);
        public bool IsTrash(long noteId, long userId);
        List<Notes> GetTrash(long userId);
        public bool EmptyTrash(long userId);
        public bool ChangeColor(long noteId, long userId, NotesModel notesModel);
        public bool IsPinned(long noteId, long userId);
        public bool IsArchive(long noteId, long userId);
        List<Notes> GetArchived(long userId);
        public bool UnArchive(long noteId, long userId);
        public bool Restore(long noteId, long userId);
        public bool AddRemainder(long noteId,long userId,DateTime dateTime);
        public bool DeleteRemainder(long noteId, long userId);
        public bool AddImage(long noteId, IFormFile image); 
        public bool RemoveImage(long noteId);
    }
}


















