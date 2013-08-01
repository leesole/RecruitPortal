using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELegal.RecruitmentPortal.Model
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public ICollection<UserProfile> UserProfiles { get; set; }

        public Role()
        {
            this.UserProfiles = new List<UserProfile>();
        }
    }
}
