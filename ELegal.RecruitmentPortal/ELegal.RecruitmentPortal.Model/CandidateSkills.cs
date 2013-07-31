using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELegal.RecruitmentPortal.Model
{
    public class CandidateSkills
    {
        [Key]
        public int CandidateSkillsId { get; set; }
        public string SkillName { get; set; }
    }
}
