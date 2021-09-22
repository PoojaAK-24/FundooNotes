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
        public bool IsTrash(long noteId, long userId)
        {
            try
            {
                return this._notesRL.IsTrash(noteId, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Notes> GetTrash(long userId)
        {
            try
            {
                return _notesRL.GetTrash(userId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool EmptyTrash(long userId)
        {
            try
            {
                return _notesRL.EmptyTrash(userId);
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

        public bool IsArchive(long noteId, long userId)
        {
            try
            {
                return this._notesRL.IsArchive(noteId, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Notes> GetArchived(long userId)
        {
            try
            {
                return _notesRL.GetArchived(userId);
            }
            catch (Exception)
            {
                throw;

            }
        }
        public bool UnArchive(long noteId, long userId)
        {
            try
            {
                return _notesRL.UnArchive(noteId, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Restore(long noteId, long userId)
        {
            try
            {
                return _notesRL.Restore(noteId, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AddRemainder(long noteId, long userId, DateTime dateTime)
        {
            try
            {
                return _notesRL.AddRemainder(noteId, userId, dateTime);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool DeleteRemainder(long noteId, long userId)
        {
            try
            {
                return _notesRL.DeleteRemainder(noteId, userId);
            }
            catch (Exception)
            {
                throw;
             }
        }

    }
}
























