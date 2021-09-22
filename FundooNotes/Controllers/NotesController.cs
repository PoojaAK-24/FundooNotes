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
    [Route("notes")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private INotesBL _notesBL;

        public NoteController(INotesBL notesBL)
        {
            _notesBL = notesBL;
        }

        private long GetTokenId()
        {
            long userId = Convert.ToInt64(User.FindFirst("Id").Value);
            return userId;
        }

        [HttpGet("GetNotes")]
        public IActionResult GetNotes()
        {
            try
            {
                long userId = GetTokenId();
                var NotesList = _notesBL.GetAllNotes(userId);

                return this.Ok(new { Success = true, message = "Get User Notes Successfully.", Data = NotesList });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("AddNote")]
        public IActionResult AddNote(NotesModel notesModel)
        {
            try
            {
                long UserID = GetTokenId();
                bool result = _notesBL.AddNotes(notesModel, UserID);

                if (result == true)
                {
                    return Ok(new { Success = true, message = "Notes added Successfully !!" });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Adding Notes is unsuccessfull !!" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { Success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }

        [HttpPut("UpdateNotes")]
        public IActionResult UpdateNotes(long id, NotesModel notesModel)
        {
            try
            {
                var userId = GetTokenId();
                var result = this._notesBL.UpdateNotes(id, userId, notesModel);

                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "Notes Updated SuccessFully", id });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Notes updation failed" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message, stackTrace = e.StackTrace });
            }

        }
        
        [HttpDelete("DeleteNotes")]
        public IActionResult DeleteNotes(long id)
        {
            try
            {
                long userId = GetTokenId();
                var result = this._notesBL.DeleteNotes(id, userId);

                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "Notes Deleted SuccessFully.", id });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Notes deletion failed." });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message, stackTrace = e.StackTrace });
            }

        }
        

        [HttpDelete]
        [Route("Trash")]
        public IActionResult IsTrash(long noteId)
        {
            try
            {

                long userId = GetTokenId();
                bool result = _notesBL.IsTrash(noteId, userId);

                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "Notes added into the trash." });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Notes remains the same" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new
                {
                    success = false,
                    message = e.Message,
                    stackTrace = e.StackTrace
                });
            }

        }

        [HttpGet]
        [Route("Trashed")]
        public IActionResult GetTrash()
        {
            try
            {
                long userId = GetTokenId();
                var trashList = _notesBL.GetTrash(userId);

                if (trashList.Count != 0)
                {
                    return this.Ok(new { Success = true, message = "These are your Trash Notes.", Data = trashList });
                }
                else if (trashList.Count == 0)
                {
                    return BadRequest(new { Success = false, message = "Trash notes is empty" });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Unsucessfull" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { Success = false, message = e.Message, stackTrace = e.StackTrace });

            }
        }

        [HttpDelete]
        [Route("EmptyTrash")]
        public IActionResult EmptyTrash()
        {
            try
            {
                long userId = GetTokenId();
                bool result = _notesBL.EmptyTrash(userId);

                if (result == true)
                {
                    return Ok(new { Success = true, message = "Deleted all trashed notes Successfully." });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Deletion failed." });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }


        [HttpPut("Color")]
        public IActionResult ChangeColor(long noteId, NotesModel notesModel)
        {
            long userId = GetTokenId();
            bool result = _notesBL.ChangeColor(noteId, userId, notesModel);

            try
            {
                if (result == true)
                {
                    return Ok(new { Success = true, message = "Color changed Successfully !!" });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Color changed unsuccessfull" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { Success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }

        [HttpPut("Pinned")]
        public IActionResult IsPinned(long noteId)
        {
            long userId = GetTokenId();
            bool result = _notesBL.IsPinned(noteId, userId);

            try
            {
                if (result == true)
                {
                    return Ok(new { Success = true, message = "Successful" });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Unsuccessful" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { Success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }
        [HttpPut]
        [Route("Archive")]
        public IActionResult IsArchive(long noteId)
        {

            try
            {
                long userId = GetTokenId();
                bool result = _notesBL.IsArchive(noteId, userId);

                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "Notes Archived." });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Archive remains the same" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new
                {
                    success = false,
                    message = e.Message,
                    stackTrace = e.StackTrace
                });
            }

        }

        
        [HttpGet]
        [Route("Archived")]
        public IActionResult GetArchived()
        {
            try
            {
                long userId = GetTokenId();
                var archivedList = _notesBL.GetArchived(userId);

                if (archivedList.Count != 0)
                {
                    return this.Ok(new { Success = true, message = "These are your Archived Notes", Data = archivedList });
                }
                else if (archivedList.Count == 0)
                {
                    return BadRequest(new { Success = false, message = "Archived notes is empty" });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Unsuccessfull" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { Success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }

        [HttpPut]
        [Route("Unarchive")]
        public IActionResult Unarchive(long noteId)
        {
            try
            {
                long userId = GetTokenId();
                bool result = _notesBL.UnArchive(noteId, userId);

                if (result == true)
                {
                    return Ok(new { Success = true, message = "Notes Unarchived Successfully." });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Unsuccessful" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { Success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }



        [HttpPut]
        [Route("Restore")]
        public IActionResult Restore(long noteId)
        {
            try
            {
                long userId = GetTokenId();
                bool result = _notesBL.Restore(noteId, userId);

                if (result == true)
                {
                    return Ok(new { Success = true, message = "Notes restored from trash Successfully." });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Unsuccessful" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }
        [HttpPut]
        [Route("AddRemainder")]
        public IActionResult AddRemainder(long noteId)
        {
            try
            {
                long userId = GetTokenId();
                bool result = _notesBL.AddRemainder(noteId,userId,DateTime.Now);

                if (result == true)
                {
                    return Ok(new { Success = true, message = "Remainder added Successfully." });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Unsuccessful" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }
        [HttpDelete]
        [Route("DeleteRemainder")]
        public IActionResult DeleteRemainder(long noteId)
        {
            try
            {
                long userId = GetTokenId();
                bool result = _notesBL.DeleteRemainder(noteId, userId);

                if (result == true)
                {
                    return Ok(new { Success = true, message = "Remainder deleted Successfully." });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Remainder deletion Unsuccessful" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }
    }
}





