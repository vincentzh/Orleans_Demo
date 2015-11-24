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
    public class UserRoleLinkPresenter
    {
        readonly UserRoleLinkRepository _userRoleLinkRepository =new UserRoleLinkRepository();
        readonly UserRepository _userRepository = new UserRepository();
        readonly RoleRepository _roleRepository=new RoleRepository();
        readonly BurrowFramework _burrow=new BurrowFramework();
        public Task<UserRoleLinkMessage> Get(int id)
        {
            _burrow.InitWorkSpace();
            var userRoleLink = _userRoleLinkRepository.Get(id);
            _burrow.CloseWorkSpace();
                
            return userRoleLink!=null?Task.FromResult(new UserRoleLinkMessage()
            {
                User = new UserMessage(){Age=userRoleLink.User.Age,Name = userRoleLink.User.Name,Id = userRoleLink.User.Id},
                Role=new RoleMessage()
                {
                    Name = userRoleLink.Role.Name,
                    Id=userRoleLink.Role.Id
                
                },
                Id = userRoleLink.Id

            }):Task.FromResult((UserRoleLinkMessage)null);
        }

        public Task<UserRoleLinkMessage> Create(int userId, int roleId)
        {
            _burrow.InitWorkSpace();
            var user = _userRepository.Get(userId);
            var role = _roleRepository.Get(roleId);
            var userRoleLink = new UserRoleLink(user, role);
            var userRoleLinkRepository = new UserRoleLinkRepository();
            userRoleLinkRepository.Save(userRoleLink);
            _burrow.CloseWorkSpace();
            return Task.FromResult(new UserRoleLinkMessage()
            {
                Role = new RoleMessage() {Id = role.Id, Name = role.Name},
                User = new UserMessage() {Id = user.Id, Age = user.Age, Name = user.Name},
                Id = userRoleLink.Id
            });
        }
    }

}
