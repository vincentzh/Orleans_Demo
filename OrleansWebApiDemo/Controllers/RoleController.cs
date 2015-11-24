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
    [RoutePrefix("Role")]
    public class RoleController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(RoleMessage))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var role =await RoleGrain().GetRole(id);
            if (role != null)
                return Json(role);
            else
            {
                return NotFound();
            }
        }

        private static IRoleGrain RoleGrain()
        {
            return GrainClient.GrainFactory.GetGrain<IRoleGrain>(Guid.NewGuid());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="createRole"></param>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(RoleMessage))]
        public async Task<IHttpActionResult> Post([FromBody]CreateRole createRole)
        {

            var role= await RoleGrain().CreateRole(createRole);
            if (role != null)
                return Ok(new {id = role.Id});
            return BadRequest();
        } 
    }
}
