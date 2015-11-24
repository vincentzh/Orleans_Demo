using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using OrleansGrainInterface;
using Presenters;

namespace OrleansGrainClass
{
    public class RoleGrain:IRoleGrain
    {
        readonly RolePresenter _rolePresenter=new RolePresenter();
        public async Task<RoleMessage> GetRole(int id)
        {
         return  await _rolePresenter.Get(id);

        }

        public async Task<RoleMessage> CreateRole(CreateRole createRole)
        {
            return await _rolePresenter.Create(createRole);
        }


    }
}
