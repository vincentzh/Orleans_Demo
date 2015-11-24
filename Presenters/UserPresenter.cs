using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DTO;
using NHibernate.Burrow;

namespace Presenters
{
    public class UserPresenter
    {
        private readonly UserRepository _userRepository = new UserRepository();
        readonly BurrowFramework _burrow=new BurrowFramework();
        public Task<UserMessage> Get(int i)
        {
            _burrow.InitWorkSpace();
            var user = _userRepository.Get(i);
            _burrow.CloseWorkSpace();

            return user != null
                ? Task.FromResult(new UserMessage()
                {
                    Name = user.Name,
                    Age = user.Age,
                    Id = user.Id
                })
                : null;
        }

        public Task<UserMessage> Create(CreateUser createUser)
        {
            var user = new User
            {
                Age = createUser.Age,
                Name = createUser.Name
            };
            _burrow.InitWorkSpace();
            _userRepository.Save(user);
            _burrow.CloseWorkSpace();
            return Task.FromResult(new UserMessage()
            {
                Name = user.Name,
                Age = user.Age,
                Id = user.Id
            });
            ;
        }

        public Task<IEnumerable<UserMessage>> FindByRole(int roleId)
        {
            _burrow.InitWorkSpace();
            var users = _userRepository.FindByRoleId(roleId);
            _burrow.CloseWorkSpace();
            return users != null
                ? Task.FromResult(users.Select(x => new UserMessage()
                {
                    Name = x.Name,
                    Age = x.Age,
                    Id = x.Id
                }))
                : null;
            ;
        }
    }
}