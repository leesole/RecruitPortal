using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELegal.RecruitmentPortal.Model;

namespace ELegal.RecruitmentPortal.Web.Areas.Recruitment.ViewModels.Candidate
{
    public class EditCandidate
    {
        public int CandidateId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }



        public MetaKeyValue Gender { get; set; }
        public List<MetaKeyValue> Genders { get; set; }
    }
}