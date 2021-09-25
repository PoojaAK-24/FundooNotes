using CommonLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entity
{
   public class Collaboration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CollaboratorId { get; set; }

        [ForeignKey("Notes")]
        public long NotesId { get; set; }
        public virtual Notes Notes { get; set; }

        [ForeignKey("User")]
        public long? UserId { get; set; }

        public virtual User User { get; set; }
   
        public string CollaboratorEmail{ get; set; }
   }
}
