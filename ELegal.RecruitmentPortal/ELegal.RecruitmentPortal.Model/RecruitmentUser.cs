using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELegal.RecruitmentPortal.Model
{
    public class RecruitmentUser :IRpAudit
    {
        [Key]
        public int RecruitmentUserId { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual RecruitmentCompany RecruitmentCompany { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedUser { get; set; }
        public decimal Version { get; set; }
    }
}
