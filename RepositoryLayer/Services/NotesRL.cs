﻿using CommonLayer;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class NotesRL : INotesRL
    {
        private UserContext _userContext;

        public NotesRL(UserContext userContext)
        {
            _userContext = userContext;
        }

        public bool AddNotes(NotesModel notesModel, long userId)
        {
            try
            {
                Notes note = new Notes();
                note.Title = notesModel.Title;
                note.Message = notesModel.Message;
                note.Remainder = notesModel.Remainder;
                note.Color = notesModel.Color;
                note.image = notesModel.image;
                note.isArchive = notesModel.isArchive;
                note.isTrash = notesModel.isTrash;
                note.isPin = notesModel.isPin;
                note.CreatedAt = DateTime.Now;
                note.ModifiedAt = null;
                note.UserId = userId;


                _userContext.Notes.Add(note);
                int result = _userContext.SaveChanges();

                if (result > 0)
                {
                    return true;
                }
                else { return false; }
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
                var result = _userContext.Notes.Where(e => e.UserId == userId).ToList();

                return result;
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
                var result = _userContext.Notes.FirstOrDefault(e => e.Id == id && e.UserId == userId);

                if (result != null)
                {

                    _userContext.Notes.Remove(result);
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

        public bool UpdateNotes(long id, long userId, NotesModel notesModel)
        {
            try
            {
                var result = _userContext.Notes.FirstOrDefault(e => e.Id == id && e.UserId == userId);

                if (result != null)
                {
                    if (notesModel.Title != null)
                    {
                        result.Title = notesModel.Title;
                    }
                    if (notesModel.Message != null)
                    {
                        result.Message = notesModel.Message;
                    }

                    result.ModifiedAt = DateTime.Now;
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
        public bool ChangeColor(long noteId, long userId, NotesModel notesModel)
        {
            try
            {
                var result = _userContext.Notes.FirstOrDefault(e => e.Id == noteId && e.UserId == userId);

                if (result != null)
                {
                    result.Color = notesModel.Color;
                    result.ModifiedAt = DateTime.Now;
                }
                int changes = _userContext.SaveChanges();

                if (changes > 0)
                {
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

        public bool IsPinned(long noteId, long userId)
        {
            try
            {
                var result = _userContext.Notes.FirstOrDefault(e => e.Id == noteId && e.UserId == userId);

                if (result != null)
                {
                        if (result.isPin == true)
                        {
                            result.isPin = false;
                            this._userContext.SaveChanges();
                            return true;
                        }
                        else
                        {
                            result.isPin = true;
                            this._userContext.SaveChanges();
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
        

        public bool IsArchive(long noteId,long userId)
        {
            try
            {
                var result = _userContext.Notes.FirstOrDefault(e => e.Id == noteId && e.UserId == userId);

                if (result != null)
                {
                    result.isArchive = true;
                    result.isTrash = false;

                    result.ModifiedAt = DateTime.Now;
                }
                int changes = _userContext.SaveChanges();

                if (changes > 0)
                    return true;

                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool IsTrash(long noteId,long userId)
        {
            try
            {
                var result = _userContext.Notes.FirstOrDefault(e => e.Id == noteId && e.UserId == userId);

                if (result != null)
                {
                    result.isTrash = true;
                    result.isArchive = false;

                    result.ModifiedAt = DateTime.Now;
                }
                int changes = _userContext.SaveChanges();

                if (changes > 0)
                { return true; }

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
        public List<Notes> GetTrash(long userId)
        {
            try
            {
                var result = _userContext.Notes.Where(e => e.UserId == userId && e.isTrash == true).ToList();

                return result;
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
                var result = _userContext.Notes.Where(e => e.UserId == userId && e.isArchive == true).ToList();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
       

