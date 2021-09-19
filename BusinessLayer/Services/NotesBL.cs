using BusinessLayer.Interface;
using CommonLayer;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class NoteBL : INotesBL
    {
        private INotesRL _notesRL;

        public NoteBL(INotesRL notesRL)
        {
            _notesRL = notesRL;
        }

        public bool AddNotes(NotesModel notesModel, long Id)
        {
            try
            {
                return _notesRL.AddNotes(notesModel, Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Notes> GetAllNotes(long userId)
        {
            try
            {
                return _notesRL.GetAllNotes(userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteNotes(long id, long userId)
        {
            try
            {
                return this._notesRL.DeleteNotes(id, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateNotes(long id, long userId, NotesModel notesModel)
        {
            try
            {
                return this._notesRL.UpdateNotes(id, userId, notesModel);
            }
            catch (Exception)
            {
                throw;
             }
        }
        public bool ChangeColor(long noteId, long userId, NotesModel notesModel)
        {
            try
            {
                return this._notesRL.ChangeColor(noteId, userId, notesModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsPinned(long noteId, long userId)
        {
            try
            {
                return _notesRL.IsPinned(noteId, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsArchive( long noteId,long userId, bool value)
        {
            try
            {
                return this._notesRL.IsArchive(noteId, userId, value);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsTrash(long noteId,long userId, bool value)
        {
            try
            {
                return this._notesRL.IsTrash(noteId,userId,value);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

