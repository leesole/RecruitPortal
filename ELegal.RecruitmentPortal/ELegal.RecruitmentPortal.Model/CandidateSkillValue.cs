using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELegal.RecruitmentPortal.Model
{
    public class CandidateSkillValue
    {
        [Key]
        public int CandidateSkillValueId { get; set; }
        public virtual Candidate Candidate { get; set; }
        public string Value { get; set; }
    }
}
