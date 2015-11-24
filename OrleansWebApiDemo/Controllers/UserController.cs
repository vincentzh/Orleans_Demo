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
    [RoutePrefix("User")]
    public class UserController : ApiController
    {
     
        [HttpGet]
        [ResponseType(typeof(UserMessage))]
        public async Task<UserMessage> Get(int id)
        {
            return await UserGrain().Get(id);
        }

        private static IUserGrain UserGrain()
        {
           return  GrainClient.GrainFactory.GetGrain<IUserGrain>(Guid.NewGuid());
            
        }

        [HttpPost]
        [ResponseType(typeof(UserMessage))]
        public async Task<UserMessage> Post([FromBody]CreateUser createUser)
        {
           return await UserGrain().CreateUser(createUser);
        } 


    }
}
