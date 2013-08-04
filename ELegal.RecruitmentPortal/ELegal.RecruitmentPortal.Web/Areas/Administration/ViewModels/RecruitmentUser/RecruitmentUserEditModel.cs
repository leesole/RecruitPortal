using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ELegal.RecruitmentPortal.Web.Models;

namespace ELegal.RecruitmentPortal.Web.Areas.Administration.ViewModels.RecruitmentUser
{
    public class RecruitmentUserEditModel : IViewModel
    {
        public RecruitmentUserEditModel()
        {
            
        }

        public int RecruitmentUserId { get; set; }
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        
        public int RecruitmentCompanyId { get; set; }


        public string TelephoneNumber { get; set; }
        public string MobileNumber { get; set; }

        
        public ScreenType ScreenType { get; set; }
    }
}