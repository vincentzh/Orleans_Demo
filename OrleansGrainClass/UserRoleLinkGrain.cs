using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Orleans;
using OrleansGrainInterface;
using Presenters;

namespace OrleansGrainClass
{

    public   class UserRoleLinkGrain:Grain,IUserRoleLinkGrain
    {
     readonly UserRoleLinkPresenter _userRoleLinkPresenter=new UserRoleLinkPresenter();
     public Task<UserRoleLinkMessage> Get(int userRoleLinkId)
     {
        return _userRoleLinkPresenter.Get(userRoleLinkId);
     }


     public Task<UserRoleLinkMessage> Create(int userId,int roleId)
     {
         return _userRoleLinkPresenter.Create(userId, roleId);
     }
    }
}
