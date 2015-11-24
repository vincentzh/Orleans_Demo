using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Orleans;

namespace OrleansGrainInterface
{
 public   interface IUserRoleLinkGrain:IGrainWithGuidKey
 {
     Task<UserRoleLinkMessage> Get(int userRoleLinkId);
     Task<UserRoleLinkMessage> Create(int userId, int roleId);
 }
}
