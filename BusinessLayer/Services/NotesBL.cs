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

        public List<Notes> GetAllNotes()
        {
            try
            {
                return _notesRL.GetAllNotes();
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
    }
}

