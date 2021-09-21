using CommonLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface ICollaboratorBL
    {

        bool AddCollaborator(string collaboratorEmailId, long noteId, long userId);
        List<Collaboration> GetCollaborator(long noteId, long userId);
        bool RemoveCollaborator(string collaboratorEmailId, long noteId, long userId);


    }
}
