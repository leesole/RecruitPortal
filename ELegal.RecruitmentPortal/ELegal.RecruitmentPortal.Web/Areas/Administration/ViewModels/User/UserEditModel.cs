using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ELegal.RecruitmentPortal.Model;
using ELegal.RecruitmentPortal.Web.Models;

namespace ELegal.RecruitmentPortal.Web.Areas.Administration.ViewModels.User
{
    public class UserEditModel : IViewModel
    {
        public UserEditModel()
        {
            Roles = new List<Role>();
        }


        public List<Role> CurrentRoles { get; set; } 
        public Model.UserProfile UserProfile { get; set; }
        public List<Role> Roles { get; set; }
        public ScreenType ScreenType { get; set; }
    }
}