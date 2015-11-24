using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DTO;
using Orleans;
using OrleansGrainInterface;
using Presenters;

namespace OrleansWebApiDemo.Controllers
{
    [RoutePrefix("UserRoleLink")]
    public class UserRoleLinkController : ApiController
    {

        IUserRoleLinkGrain GetUserRoleLinkGrain()
        {
            return GrainClient.GrainFactory.GetGrain<IUserRoleLinkGrain>(Guid.NewGuid());
        }
        [HttpGet]
        [ResponseType(typeof(UserRoleLinkMessage))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var userRoleLink= await GetUserRoleLinkGrain().Get(id);
            if (userRoleLink != null)
                return Json(userRoleLink);
            return NotFound();
        }

        [HttpPost]
        [ResponseType(typeof(UserRoleLinkMessage))]
        public async Task<IHttpActionResult> Post(int userId,int roleId)
        {
             var userRoleLink= await GetUserRoleLinkGrain().Create(userId, roleId);
            if (userRoleLink != null)
                return Ok(new {id = userRoleLink.Id});
            return BadRequest();
        }

    }
}
