using BusinessLayer.Interface;
using CommonLayer;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class CollaboratorBL : ICollaboratorBL
    {
        private ICollaboratorRL _collaboratorRL;

        public CollaboratorBL(ICollaboratorRL collaboratorRL)
        {
            this._collaboratorRL = collaboratorRL;
        }
        public bool AddCollaborator(string collboratorEmailId,long noteId,long userId)
        {
            try
            {
                return this._collaboratorRL.AddCollaborator(collboratorEmailId, noteId, userId);
            }
            catch(Exception)
            {
                throw;
            }
        }
        public List<Collaboration> GetCollaborator(long noteId, long userId)
        {
            try
            {
                return _collaboratorRL.GetCollaborator(noteId, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool RemoveCollaborator(string collaboratorEmailId, long noteId, long userId)
        {
            try
            {
                return this._collaboratorRL.AddCollaborator(collaboratorEmailId, noteId, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
        

       