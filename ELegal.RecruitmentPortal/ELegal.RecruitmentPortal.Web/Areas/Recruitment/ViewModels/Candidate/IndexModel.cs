﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELegal.RecruitmentPortal.Web.Areas.Recruitment.ViewModels.Candidate
{
    public class IndexModel
    {
        public IndexModel()
        {
            CandidateItems = new List<CandidateItem>();
        }
        public List<CandidateItem> CandidateItems { get; set; }

    }

    public class CandidateItem
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
