using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserRoleLinkMessage
    {
        public UserMessage User { get; set; }
        public RoleMessage Role { get; set; }
        public int Id { get; set; }
    }
}