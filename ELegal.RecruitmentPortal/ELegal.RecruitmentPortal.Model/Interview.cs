using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELegal.RecruitmentPortal.Model
{
    public class Interview : IRpAudit
    {
        [Key]
        public int InterviewId { get; set; }

        public string Description { get; set; }
        public DateTime InterviewDate { get; set; }
        public virtual Submission Submission { get; set; }
        public string Notes { get; set; }
        public string RecruiterFeedBack { get; set; }

        public virtual ICollection<UserProfile> Interviewers { get; set; }

        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedUser { get; set; }
        public decimal Version { get; set; }
    }
}
