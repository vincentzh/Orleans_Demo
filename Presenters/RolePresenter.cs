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
    public class RolePresenter
    {
        private readonly RoleRepository _roleRepository = new RoleRepository();
        BurrowFramework _burrow=new BurrowFramework();
        public Task<RoleMessage> Get(int id)
        {
            _burrow.InitWorkSpace();
            var role = _roleRepository.Get(id);
            _burrow.CloseWorkSpace();
            return role != null
                ? Task.FromResult(new RoleMessage()
                {
                    Name = role.Name,
                    Id = role.Id
                })
                : null;
        }

        public Task<RoleMessage> Create(CreateRole createRole)
        {
            var role = new Role {Name = createRole.Name};
         _burrow.InitWorkSpace();
            _roleRepository.Save(role);
            _burrow.CloseWorkSpace();
            return Task.FromResult(new RoleMessage()
            {
                Name = role.Name,
                Id = role.Id
            });
        }
    }
}