using CommonLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ICollaboratorRL
    {
        bool AddCollaborator(string collboratorEmailId, long noteId, long userId);
        List<Collaboration> GetCollaborator(long noteId, long userId);
        bool RemoveCollaborator(string collaboratorEmailId, long noteId, long userId);

    }
}
