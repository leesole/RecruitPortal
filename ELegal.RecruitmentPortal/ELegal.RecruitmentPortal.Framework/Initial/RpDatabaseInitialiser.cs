using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELegal.RecruitmentPortal.Framework.DataContext;
using ELegal.RecruitmentPortal.Model;

namespace ELegal.RecruitmentPortal.Framework.Initial
{
    public class RpDatabaseInitialiser :
        //CreateDatabaseIfNotExists<RpContext>      // when model is stable
         DropCreateDatabaseIfModelChanges<RpContext> 
    {
        protected override void Seed(RpContext context)
        {
            SeedData(context);
            base.Seed(context);
        }

        public void SeedData(RpContext context)
        {
            var recruitmentCompanyList = new List<RecruitmentCompany>()
                {
                    new RecruitmentCompany()
                        {
                            CompanyName = "RecruitmentComp1"
                        },

                };
            recruitmentCompanyList.ForEach(c => context.RecruitmentCompanies.AddOrUpdate(p => p.CompanyName, c));

            #region Menu

            var menuList = new List<Menu>()
                {
                      new Menu()
                        {
                            MenuName = "Candidates",
                            MenuType = 2,
                            Link = "Candidates",
                            Icon = "icon-home",
                            OrderPosition = 1
                        },
                          new Menu()
                        {
                            MenuName = "Vacancies",
                            MenuType = 2,
                            Link = "Vacancies",
                            Icon = "icon-home",
                            OrderPosition = 2
                        },
                    new Menu()
                        {
                            MenuName = "Controls",
                            MenuType = 2,
                            Link = "controltype",
                            Icon = "icon-home",
                            OrderPosition = 3
                        },
                     new Menu()
                        {
                            MenuName = "Templates",
                            MenuType = 2,
                            Link = "Questions",
                            Icon = "icon-home",
                            OrderPosition = 1
                        },
                     new Menu()
                        {
                            MenuName = "Settings",
                            MenuType = 2,
                            Link = "settings",
                            Icon = "icon-cogs",
                            OrderPosition = 5
                        }

                };
            menuList.ForEach(c => context.Menus.AddOrUpdate(p => p.MenuName, c));
            #endregion
        }
    }
}
