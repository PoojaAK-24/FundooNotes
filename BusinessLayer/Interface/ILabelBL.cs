using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;
using RepositoryLayer.Entity;

namespace BusinessLayer.Interface
{
   public interface ILabelBL
    {
       public bool AddLabel(long noteId, long userId, LabelModel labelModel);

       List<Label> GetNoteLabels (long noteId, long userId);
       public bool EditLabelName(long labelId, long userId, LabelModel labelModel);

       public bool DeleteLabel(long userId, string labelName);




    }
}
