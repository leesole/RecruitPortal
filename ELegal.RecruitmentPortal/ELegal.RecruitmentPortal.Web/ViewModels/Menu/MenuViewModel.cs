using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELegal.RecruitmentPortal.Web.ViewModels.Menu
{

    public class MenuViewModel
    {
        public string SelectedMenu { get; set; }
        public IEnumerable<Model.Menu> Menus { get; set; }
    }

}