using System;
using System.Collections.Generic;

#nullable disable

namespace DemoAuthorization.Models
{
    public partial class Role
    {
        public Role()
        {
            AccountRoles = new HashSet<AccountRole>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AccountRole> AccountRoles { get; set; }
    }
}
