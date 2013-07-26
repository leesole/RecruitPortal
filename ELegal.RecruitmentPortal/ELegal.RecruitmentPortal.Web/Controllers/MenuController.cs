using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELegal.RecruitmentPortal.Framework.DataContext;
using ELegal.RecruitmentPortal.Web.ViewModels.Menu;

namespace ELegal.RecruitmentPortal.Web.Controllers
{
    public class MenuController : Controller
    {
        //
        // GET: /Menu/

        [ChildActionOnly]
        public ActionResult AppSideMenu(string selected)
        {
            using (var context = new RpContext())
            {
                var menuViewModel = new MenuViewModel();
                var menus = context.Menus.Where(mnu => mnu.MenuType == 2).OrderBy(mnu => mnu.OrderPosition).ToList();
                menuViewModel.Menus = menus;
                menuViewModel.SelectedMenu = selected;
                return  PartialView(menuViewModel);
            }
        }

    }
}
