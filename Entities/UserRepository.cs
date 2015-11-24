using System.Collections.Generic;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace Domain
{
    public class UserRepository : NHibernate.Burrow.AppBlock.DAOBases.GenericDAO<User>
    {
        public IEnumerable<User> FindByRoleId(int roleId)
        {
            return
                CreateCriteria()
                    .CreateAlias("UserRoleLinks", "link")
                    .Add(Restrictions.Eq("link.Role.Id", roleId))
                    .List<User>();
        }
    }
}