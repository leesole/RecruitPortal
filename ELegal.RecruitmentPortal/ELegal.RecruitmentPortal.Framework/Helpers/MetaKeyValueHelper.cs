using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELegal.RecruitmentPortal.Framework.DataContext;
using ELegal.RecruitmentPortal.Model;

namespace ELegal.RecruitmentPortal.Framework.Helpers
{
    public class MetaKeyValueHelper
    {
        public MetaKeyValue GetMetaKey(string entityType, string metaType, string value)
        {
            using (var context = new RpContext())
            {
                return context.MetaKeyValues.FirstOrDefault(mkv => mkv.MetaType == metaType && mkv.EntityType == entityType && mkv.Value == value);
            }
        }

    }
}
