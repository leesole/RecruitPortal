using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELegal.RecruitmentPortal.Framework.DataContext;
using ELegal.RecruitmentPortal.Model;

namespace ELegal.RecruitmentPortal.Framework.Helpers
{
    public static class UserHelper
    {
        public static bool IsUserInRole(string userName, string role)
        {
            using (var context = new RpContext())
            {
                var user = context.UserProfile.Where(usr => usr.UserName == userName
                                                            && (usr.Roles.Count(o => o.RoleName == role) > 0));
                return (user == null);
            }
        }
    }
}
