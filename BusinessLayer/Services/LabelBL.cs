using BusinessLayer.Interface;
using CommonLayer;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class LabelBL : ILabelBL
    {
        private ILabelRL _labelRL;
        public LabelBL(ILabelRL labelRL)
        {
            this._labelRL = labelRL;

        }

        public bool AddLabel(long noteId, long userId, LabelModel labelModel)
        {
            try
            {
                return _labelRL.AddLabel(noteId, userId, labelModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Label> GetNoteLabels (long noteId, long userId)
        {
            try
            {
                return _labelRL.GetNoteLabels(noteId, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EditLabelName(long labelId, long userId, LabelModel labelModel)
        {
            try
            {
                return _labelRL.EditLabelName(labelId, userId, labelModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteLabel(long userId, string labelName)
        {
            try
            {
                return _labelRL.DeleteLabel(userId, labelName);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
          

