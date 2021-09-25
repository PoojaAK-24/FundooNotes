//-----------------------------------------------------------------------
// <copyright file="ICollaboratorBL.cs" company="Company">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Pooja Reddy</author>
//-----------------------------------------------------------------------
namespace BusinessLayer.Interface
{
using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer;
using RepositoryLayer.Entity;

 public interface ICollaboratorBL
    {
        bool AddCollaborator(string collaboratorEmailId, long noteId, long userId);
        List<Collaboration> GetCollaborator(long noteId, long userId);
        bool RemoveCollaborator(string collaboratorEmailId, long noteId, long userId);
    }
}
