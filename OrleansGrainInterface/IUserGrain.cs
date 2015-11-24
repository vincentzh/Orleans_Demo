using System.Threading.Tasks;
using DTO;
using Orleans;

namespace OrleansGrainInterface
{
    /// <summary>
    /// Grain interface IUserGrain
    /// </summary>
    public interface IUserGrain : IGrainWithGuidKey
    {
        Task<UserMessage> CreateUser(CreateUser createUser);
        Task<UserMessage> Get(int userId);
    }
}
