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
        [HttpGet]
        public IActionResult GetNotes()
        {
            try
            {
                var NotesList = _notesBL.GetAllNotes();

                return this.Ok(new { Success = true, message = "Get User Notes Successfully.", Data = NotesList });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
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

       

        [HttpDelete("{id:long}")]
        public IActionResult DeleteNotes(long id)
        {
            try
            {
                long userId = GetTokenId();
                var result = this._notesBL.DeleteNotes(id, userId);

                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "Note Deleted SuccessFully.", id });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Note deletion failed." });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message, stackTrace = e.StackTrace });
            }

        }

        [HttpPut("{id:long}")]
        public IActionResult UpdateNotes(long id, NotesModel notesModel)
        {
            try
            {
                var userId = GetTokenId();
                var result = this._notesBL.UpdateNotes(id, userId, notesModel);

                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "Note Updated SuccessFully.", id });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Note updation failed." });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message, stackTrace = e.StackTrace });
            }

        }
    }
}

