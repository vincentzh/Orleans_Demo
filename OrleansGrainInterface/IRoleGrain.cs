using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Orleans;

namespace OrleansGrainInterface
{
    public interface IRoleGrain : IGrainWithGuidKey
    {
    Task<RoleMessage> GetRole(int id);
        Task<RoleMessage> CreateRole(CreateRole createRole);
    }
}
