using CommonLayer;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using RepositoryLayer.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class CollaboratorRL : ICollaboratorRL
    {
        private UserContext _userContext;


        public CollaboratorRL(UserContext userContext)
        {
            this._userContext = userContext;
        }



        public bool AddCollaborator(string collaboratorEmailId, long noteId, long userId)
        {
            try
            {
                var resultNote = _userContext.Notes.Find(noteId);
                var checkmail = _userContext.Users.FirstOrDefault(e => e.Email == collaboratorEmailId);

                if (checkmail.Email == collaboratorEmailId)
                {
                    if (resultNote != null)
                    {
                        Collaboration collaborator = new Collaboration();
                        collaborator.CollaboratorEmail = collaboratorEmailId;
                        collaborator.UserId = userId;
                        collaborator.NotesId = noteId;
                        this._userContext.collaborations.Add(collaborator);
                        _userContext.SaveChanges();
                        return true;

                    }

                }
                return false;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Collaboration> GetCollaborator(long noteId, long userId)
        {
            try
            {
                var result = _userContext.collaborations.Where(e => e.NotesId == noteId && e.UserId == userId).ToList();

                return result;
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
                var result = _userContext.collaborations.FirstOrDefault(e => e.NotesId == noteId && e.UserId == userId && e.CollaboratorEmail == collaboratorEmailId);
                                  
                if (result != null)
                {

                    _userContext.collaborations.Remove(result);
                    _userContext.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
    
}
