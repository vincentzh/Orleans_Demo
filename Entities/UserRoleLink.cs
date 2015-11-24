using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Burrow.AppBlock.EntityBases;

namespace Domain
{
    public class UserRoleLink:PersistantObj<int>
    {
        protected UserRoleLink() { }

        public UserRoleLink(User user, Role role)
        {
            User = user;
            Role = role;
            
        }
        public User User { get; protected set; }
        public Role Role { get; protected set; }
        public override IComparable BusinessKey
        {
            get { return User.Id+BIZKEYSEP+Role.Id; }
        }

        public override int Id { get; set; }
    }
}
