using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELegal.RecruitmentPortal.Model
{
    public interface IRpAudit
    {
        bool Deleted { get; set; }
        DateTime CreatedDate { get; set; }
        string CreatedUser { get; set; }
        DateTime UpdatedDate { get; set; }
        string UpdatedUser { get; set; }
        decimal Version { get; set; }
    }
}
