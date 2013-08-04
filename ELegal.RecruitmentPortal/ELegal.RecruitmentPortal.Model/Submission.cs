using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELegal.RecruitmentPortal.Model
{
    public class Submission :IRpAudit
    {
        [Key]
        public int SubmissionId { get; set; }
        public string SubmissionName { get; set; }
        public SubmissionStatusEnum SubmissionStatus { get; set; }

        public virtual Candidate Candidate { get; set; }
        public virtual ICollection<Interview> Interviews { get; set; }
        public virtual RecruitmentUser RecruitmentUser { get; set; }
        public virtual Vacancy Vacancy { get; set; }

        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedUser { get; set; }
        public decimal Version{ get; set; }
    }
}
