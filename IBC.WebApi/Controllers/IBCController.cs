using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IBC.WebApi.Controllers
{
    [Authorize]
    public class IBCController : ApiController
    {
        public IHttpActionResult Get()
        {
            IBCService noteService = CreateIBCService();
            var notes = noteService.GetNotes();
            return Ok(notes);
        }

        private IBCService CreateIBCService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new IBCService(userId);
            return noteService;
        }
    }
}
