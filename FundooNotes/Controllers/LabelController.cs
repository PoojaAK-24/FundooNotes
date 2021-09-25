using BusinessLayer.Interface;
using CommonLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [Authorize]
    [Route("Label")]
    [ApiController]
    public class LabelController : ControllerBase
    {

        readonly private ILabelBL _labelBL;

        public LabelController(ILabelBL labelBL)
        {
            this._labelBL = labelBL;
        }
        private long GetTokenId()
        {
            long userId = Convert.ToInt64(User.FindFirst("Id").Value);
            return userId;
        }

        [HttpPost]
        public IActionResult AddLabel(long noteId, LabelModel labelModel)
        {
            try
            {
                long userId = GetTokenId();
                var result = _labelBL.AddLabel(noteId, userId, labelModel);

                if (result == true)
                {
                    return Ok(new { Success = true, message = "Label added Successfully !!" });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Label already exists !!" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { Success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }
        [HttpGet]
        public IActionResult GetNoteLabels(long noteId)
        {
            try
            {
                long userId = GetTokenId();
                var labelList = _labelBL.GetNoteLabels(noteId, userId);

                if (labelList.Count != 0)
                {
                    return this.Ok(new { Success = true, message = "These are the Labels.", Data = labelList });
                }
                else if (labelList.Count == 0)
                {
                    return BadRequest(new { Success = false, message = "No Label is added to this note." });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Something went wrong." });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { Success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }
        [HttpPut]
        public IActionResult EditLabelName(long labelId, LabelModel labelModel)
        {
            try
            {
                long userId = GetTokenId();
                bool result = _labelBL.EditLabelName(labelId, userId, labelModel);

                if (result == true)
                {
                    return Ok(new { Success = true, message = "Label changed Successfully !!" });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Label does not exists" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { Success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }
        

        [HttpDelete]
        public IActionResult DeleteLabel(LabelModel labelModel)
        {
            try
            {
                long userId = GetTokenId();
                bool result = _labelBL.DeleteLabel(userId, labelModel.LabelName);

                if (result == true)
                {
                    return Ok(new { Success = true, message = "Label Removed Successfully !!" });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Failed to Remove label !!" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { Success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }

    }
}
    


        


   
    

        
   

