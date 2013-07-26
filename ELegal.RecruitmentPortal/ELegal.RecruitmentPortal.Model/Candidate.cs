using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELegal.RecruitmentPortal.Model
{
    public class Candidate :IRpAudit
    {
        [Key]
        public int CandidateId { get; set; }

        public string FirstName { get; set; }
        public string Surname { get; set; }
        
        public string HrNotes { get; set; }
        public string RecruitmentNotes { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedUser { get; set; }
        public decimal Version { get; set; }
    }
}
