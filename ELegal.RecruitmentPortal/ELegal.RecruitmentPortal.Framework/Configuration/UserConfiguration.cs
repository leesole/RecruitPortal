using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELegal.RecruitmentPortal.Model;

namespace ELegal.RecruitmentPortal.Framework.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<UserProfile>
    {
        public UserConfiguration()
        {
            
        }


    }
}
