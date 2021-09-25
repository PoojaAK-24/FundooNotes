using CommonLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ILabelRL
    {
        public bool AddLabel(long noteId, long userId, LabelModel labelModel);

        List<Label> GetNoteLabels(long noteId, long userId);
        public bool EditLabelName(long labelId, long userId, LabelModel labelModel);

        public bool DeleteLabel(long userId, string labelName);
    }
}
