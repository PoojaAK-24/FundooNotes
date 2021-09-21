using BusinessLayer.Interface;
using CommonLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [Authorize]
    [Route("collaborator")]
    [ApiController]
    public class CollaboratorController : ControllerBase
    {
        private ICollaboratorBL _collaboratorBL;

        public CollaboratorController(ICollaboratorBL collaboratorBL)
        {
           this._collaboratorBL = collaboratorBL;
        }

        private long GetTokenId()
        {
            long userId = Convert.ToInt64(User.FindFirst("Id").Value);
            return userId;
        }
        [HttpPost("AddCollaborator")]
        public IActionResult AddCollaborator(CollaboratorModel collaboratorModel,long noteId)
        {
            try
            {
                
               long UserID = GetTokenId();
               bool result = _collaboratorBL.AddCollaborator(collaboratorModel.CollaboratorEmailId,noteId,UserID);
                if (result == true)
                {
                    return Ok(new { Success = true, message = "Collaborator added Successfully !!" });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Adding Collaborator unsuccessfull !!" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { Success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }
        [HttpGet]
        [Route("noteId/GetCollaborations")]
        public IActionResult GetCollaborator(long noteId)
        {
            try
            {
                long userId = GetTokenId();
                var collaboratorList = _collaboratorBL.GetCollaborator(noteId, userId);

                if (collaboratorList.Count != 0)
                {
                    return Ok(new { success = true, message = "Collaborations of these note are", data = collaboratorList });
                }
                else if (collaboratorList.Count == 0)
                {
                    return BadRequest(new { Success = false, message = "collaborations not found." });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Unsuccesfull" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { Success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }
        [HttpDelete]
        [Route("noteId/RemoveCollaborator")]
        public IActionResult RemoveCollaborator(long noteId, CollaboratorModel collaboratorModel)
        {
            try
            {
                long userId = GetTokenId();
                var result = _collaboratorBL.RemoveCollaborator(collaboratorModel.CollaboratorEmailId,noteId,userId);

                if (result == true)
                {
                    return Ok(new { Success = true, message = "Collaboration Removed Successfully." });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Removing Collaboration failed." });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }
    }
}





       