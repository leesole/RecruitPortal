using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELegal.RecruitmentPortal.Model;
using ELegal.RecruitmentPortal.Web.Models;

namespace ELegal.RecruitmentPortal.Web.Areas.Administration.ViewModels.RecruitmentCompany
{
    public class RecruitmentCompanyEditModel
    {
        public RecruitmentCompanyEditModel()
        {
            RatingsList = new List<SelectListItem>();
            RecruitmentUserItems = new List<RecruitmentUserItem>();
            RecruitmentCompany = new Model.RecruitmentCompany();
        }

        public ScreenType ScreenType { get; set; }
        public Model.RecruitmentCompany RecruitmentCompany { get; set; }
        public List<SelectListItem> RatingsList { get; set; }
        public List<RecruitmentUserItem> RecruitmentUserItems { get; set; } 


    }

    public class RecruitmentUserItem
    {
        public int RecruitmentUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}