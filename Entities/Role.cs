using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iesi.Collections.Generic;
using NHibernate.Burrow.AppBlock.EntityBases;

namespace Domain
{
    public class Role:PersistantObj<int>
    {
        Iesi.Collections.Generic.ISet<UserRoleLink> userRoleLinks=new HashedSet<UserRoleLink>(); 
        public string Name { get; set; }

        public ICollection<UserRoleLink> UserRoleLinks { get { return userRoleLinks; } } 

        public override IComparable BusinessKey
        {
            get { return Id; }
        }

        public override int Id { get; set; }
    }
}
