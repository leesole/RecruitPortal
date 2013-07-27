using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using ELegal.RecruitmentPortal.Framework.DataContext;
using ELegal.RecruitmentPortal.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ELegal.RecruitmentPortal.Web.Tests.SeedData
{
    [TestClass]
    public class SeedData
    {

        [TestMethod]
        public void SeedAllData()
        {
            using (var context = new RpContext())
            {
                #region RecruitmentCompany

                AddRecruitmentCompanies(context);

                #endregion

                #region MetaKeyValueForCandidate

                AddGenders(context);

                #endregion


                #region Menu

                AddMenu(context);

                #endregion

                context.SaveChanges();
            }
        }

        private static void AddMenu(RpContext context)
        {
            var menuList = new List<Menu>()
                {
                    new Menu()
                        {
                            MenuName = "Candidates",
                            MenuType = 2,
                            Link = "Candidates",
                            Icon = "group",
                            OrderPosition = 2
                        },
                    new Menu()
                        {
                            MenuName = "Vacancies",
                            MenuType = 2,
                            Link = "Vacancies",
                            Icon = "notes_2",
                            OrderPosition = 3
                        },
                    new Menu()
                        {
                            MenuName = "Interviews",
                            MenuType = 2,
                            Link = "controltype",
                            Icon = "calendar",
                            OrderPosition = 4
                        },
                    new Menu()
                        {
                            MenuName = "Settings",
                            MenuType = 2,
                            Link = "settings",
                            Icon = "settings",
                            OrderPosition = 5
                        },
                        new Menu()
                        {
                            MenuName = "Dashboard",
                            MenuType = 2,
                            Link = "/",
                            Icon = "dashboard",
                            OrderPosition = 1
                        }
                };
            foreach (var menu in menuList )
            {
                var existingMenu = context.Menus.FirstOrDefault(p => p.MenuName == menu.MenuName && p.MenuType == menu.MenuType);
                if (existingMenu == null)
                    context.Menus.Add(menu);
            }
        }

        private static void AddGenders(RpContext context)
        {
            var genders = new List<MetaKeyValue>()
                {
                    new MetaKeyValue()
                        {
                            MetaKeyValueId = 1,
                            MetaType = "Gender",
                            Value = "Male"
                        },
                    new MetaKeyValue()
                        {
                            MetaType = "Gender",
                            Value = "Female"
                        },
                };
            foreach (var gender in genders)
            {
                var gen = context.MetaKeyValues.FirstOrDefault(p => p.MetaType == gender.MetaType && p.Value == gender.Value);
                if (gen == null)
                    context.MetaKeyValues.Add(gender);
            }
        }

        private static void AddRecruitmentCompanies(RpContext context)
        {
            var recruitmentCompanyList = new List<RecruitmentCompany>()
                {
                    new RecruitmentCompany()
                        {
                            CompanyName = "RecruitmentComp1"
                        },
                };
            foreach (var recruitmentCompany in recruitmentCompanyList)
            {
                var recCompany = context.RecruitmentCompanies.FirstOrDefault(p => p.CompanyName == recruitmentCompany.CompanyName);
                if (recCompany == null)
                    context.RecruitmentCompanies.Add(recruitmentCompany);
            }
            
        }
    }
}
