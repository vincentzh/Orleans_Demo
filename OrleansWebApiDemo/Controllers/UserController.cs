using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using System.Web.Mvc;
using DTO;
using Orleans;
using OrleansGrainInterface;
using Presenters;

namespace OrleansWebApiDemo.Controllers
{
    [System.Web.Http.RoutePrefix("User")]
    public class UserController : ApiController
    {
     
        [System.Web.Http.HttpGet]
        [ResponseType(typeof(UserMessage))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var user= await  UserGrain().Get(id);
           
            if (user==null)
            {
                return NotFound();
            }
            return Json(user);
        }

        private static IUserGrain UserGrain()
        {
           return  GrainClient.GrainFactory.GetGrain<IUserGrain>(Guid.NewGuid());
            
        }

        [System.Web.Http.HttpPost]
        [ResponseType(typeof(UserMessage))]
        public async Task<IHttpActionResult> Post([FromBody]CreateUser createUser)
        {
           var user= await UserGrain().CreateUser(createUser);
            if (user != null)
                return Ok(new{id=user.Id});
            return BadRequest();
        } 


    }
}
