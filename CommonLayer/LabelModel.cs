using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer
{
   public class LabelModel
    {
        [Required]
        public string LabelName  { get; set; }
    }
}
