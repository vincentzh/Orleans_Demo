using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NHibernate.Burrow.AppBlock.EntityBases;

namespace Domain
{
    public class User:PersistantObj<int>
    {
        private Iesi.Collections.Generic.ISet<UserRoleLink> userRoleLinks = new Iesi.Collections.Generic.HashedSet<UserRoleLink>(); 
        public override IComparable BusinessKey
        {
            get { return Id; }
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public ICollection<UserRoleLink> UserRoleLinks
        {
            get { return userRoleLinks; }
        }

     
        
        public override int Id { get; set; }
    }
}
