using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELegal.RecruitmentPortal.Framework.DataContext;
using ELegal.RecruitmentPortal.Model;

namespace ELegal.RecruitmentPortal.Framework.Helpers
{
    public class UserHelper
    {
        public bool IsUserInRole(string UserName)
        {
            using (var context = new RpContext())
            {
                
            }
            return true;
        }
    }
}
