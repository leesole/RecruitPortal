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
        public string LastName { get; set; }
        public decimal CurrentSalary { get; set; }
        public decimal SalaryExpectation { get; set; }
        public bool IsUkEligible { get; set; }
        public byte[] CvFile { get; set; }
        public virtual MetaKeyValue Gender { get; set; }
        public virtual MetaKeyValue AgeCategory { get; set; }
        public virtual MetaKeyValue Ethnicity { get; set; }
        public virtual MetaKeyValue Religion { get; set; }
        public virtual MetaKeyValue SexualOrientation { get; set; }


//Carer for under 18
//Long term ill ness
//Problems related to old age
//Economic Background
//Private or State school
        
        public virtual RecruitmentUser RecruitmentUser { get; set; }
        public virtual RecruitmentCompany RecruitmentCompany { get; set; }

        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedUser { get; set; }
        public decimal Version{ get; set; }
    }
}
