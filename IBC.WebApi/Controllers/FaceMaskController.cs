using IBC.Models.FaceMaskModels;
using IBC.Services;
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
    public class FaceMaskController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            FaceMaskService faceMaskService = CreateFaceMaskService();
            var faceMasks = faceMaskService.GetFaceMasks();
            return Ok(faceMasks);
        }

        public IHttpActionResult Get(int id)
        {
            FaceMaskService faceMaskService = CreateFaceMaskService();
            var faceMask = faceMaskService.GetFaceMaskById(id);
            return Ok(faceMask);
        }

        public IHttpActionResult Post(FaceMaskCreate faceMask)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var service = CreateFaceMaskService();
            
            if (!service.CreateFaceMask(faceMask))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Put(FaceMaskEdit faceMask)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateFaceMaskService();

            if (!service.UpdateFaceMask(faceMask))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateFaceMaskService();

            if (!service.DeleteFaceMask(id))
                return InternalServerError();

            return Ok();
        }

        private FaceMaskService CreateFaceMaskService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var faceMaskService = new FaceMaskService(userId);
            return faceMaskService;
        }
    }
}
