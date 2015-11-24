using System;
using System.CodeDom;
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
        private readonly BurrowFramework _burrow = new BurrowFramework();

        public Task<UserMessage> Get(int i)
        {
            User user = null;
            _burrow.InitWorkSpace();

            user = _userRepository.Get(i);

            _burrow.CloseWorkSpace();

            return user != null
                ? Task.FromResult(new UserMessage()
                {
                    Name = user.Name,
                    Age = user.Age,
                    Id = user.Id
                })
                : Task.FromResult((UserMessage) null);
        }

        public Task<UserMessage> Create(CreateUser createUser)
        {
            var user = new User
            {
                Age = createUser.Age,
                Name = createUser.Name
            };
            _burrow.InitWorkSpace();
            try
            {
                _userRepository.Save(user);
            }
            catch (Exception ex)
            {
            }

            _burrow.CloseWorkSpace();
            return Task.FromResult(new UserMessage()
            {
                Name = user.Name,
                Age = user.Age,
                Id = user.Id
            });
        }

        public Task<List<UserMessage>> FindByRole(int roleId)
        {
            _burrow.InitWorkSpace();
            var users = _userRepository.FindByRoleId(roleId);
            _burrow.CloseWorkSpace();
            return users.Any()
                ? Task.FromResult(users.Select(x => new UserMessage()
                {
                    Name = x.Name,
                    Age = x.Age,
                    Id = x.Id
                }).ToList())
                : Task.FromResult(new List<UserMessage>());
        }
    }
}