using System;
using System.Threading.Tasks;
using DTO;
using Orleans;
using Orleans.Concurrency;
using OrleansGrainInterface;
using Presenters;

namespace OrleansGrainClass
{

    /// <summary>
    /// Grain implementation class UserGrain.
    /// </summary>
    public class UserGrain : Grain,IUserGrain 
    {
        readonly  UserPresenter _userPresenter=new UserPresenter();
        public async Task<UserMessage> CreateUser(CreateUser createUser)
        {
            
            return await _userPresenter.Create(createUser);
        }

        public async Task<UserMessage> Get(int userId)
        {
            return await _userPresenter.Get(userId);
        }

      
    }
}
