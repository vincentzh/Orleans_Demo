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
        public async Task<UserRoleLinkMessage> Get(int id)
        {
            return await GetUserRoleLinkGrain().Get(id);
        }

        [HttpPost]
        [ResponseType(typeof(UserRoleLinkMessage))]
        public async Task<UserRoleLinkMessage> Post(int userId,int roleId)
        {
            return await GetUserRoleLinkGrain().Create(userId, roleId);
        }

    }
}
