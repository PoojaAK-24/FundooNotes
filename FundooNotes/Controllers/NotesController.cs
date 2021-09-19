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

        [HttpPost("AddNote")]
        public IActionResult AddNote(NotesModel notesModel)
        {
            try
            {
                long UserID = GetTokenId();
                bool result = _notesBL.AddNotes(notesModel, UserID);

                if (result == true)
                {
                    return Ok(new { Success = true, message = "Note added Successfully !!" });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Adding Note was unsuccessfull !!" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { Success = false, message = e.Message, stackTrace = e.StackTrace });
            }
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

        [HttpPut("UpdateNotes")]
        public IActionResult UpdateNotes(long id, NotesModel notesModel)
        {
            try
            {
                var userId = GetTokenId();
                var result = this._notesBL.UpdateNotes(id, userId, notesModel);

                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "Notes Updated SuccessFully.", id });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Notes updation failed." });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message, stackTrace = e.StackTrace });
            }

        }


        [HttpPut("ChangeColor")]
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
                    return BadRequest(new { Success = false, message = "Color changed unsuccessfull !!" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { Success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }

        [HttpPut("isPinned/{noteId}")]
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
        [Route("isArchive/{noteId}")]
        public IActionResult IsArchive(long noteId, bool value)
        {

            try
            {
                long userId = GetTokenId();
                bool result = _notesBL.IsArchive(noteId, userId, value);

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

        [HttpPut]
        [Route("isTrash/{noteId}")]
        public IActionResult IsTrash(long noteId, bool value)
        {
            try
            {

                long userId = GetTokenId();
                bool result = _notesBL.IsTrash(noteId, userId, value);

                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "notes added into the trash." });
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

    }
}

