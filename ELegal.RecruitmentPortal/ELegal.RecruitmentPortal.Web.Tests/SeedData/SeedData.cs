using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using ELegal.RecruitmentPortal.Framework.DataContext;
using ELegal.RecruitmentPortal.Framework.Helpers;
using ELegal.RecruitmentPortal.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ELegal.RecruitmentPortal.Web.Tests.SeedData
{
    [TestClass]
    public class SeedData
    {

        [TestMethod]
        public void SeedUsers()
        {
            AuthConfig.InitWebSec();
        }

        [TestMethod]
        public void SeedAllData()
        {
            using (var context = new RpContext())
            {
                #region RecruitmentCompany

                AddRating(context);
                AddRecruitmentCompanies(context);
                AddRecruiters(context);

                #endregion

                #region MetaKeyValueForCandidate

                AddGenders(context);
                AddAgeCategories(context);
                AddReligion(context);

                #endregion

                #region Vacancies

                AddVacancyTypes(context);

                #endregion
                
                
                #region Candidates
                AddCandidates(context);
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
                            EntityType = "Candidate",
                            MetaType = "Gender",
                            Value = "Male"
                        },
                    new MetaKeyValue()
                        {
                            EntityType = "Candidate",
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

        private static void AddAgeCategories(RpContext context)
        {
            var ageCategories = new List<MetaKeyValue>()
                {
                    new MetaKeyValue()
                        {
                            EntityType = "Candidate",
                            MetaType = "AgeCategory",
                            Value = "18-30"
                        },
                    new MetaKeyValue()
                        {
                            EntityType = "Candidate",
                            MetaType = "AgeCategory",
                            Value = "31-60"
                        },
                };
            foreach (var ageCategory in ageCategories)
            {
                var age = context.MetaKeyValues.FirstOrDefault(p => p.MetaType == ageCategory.MetaType && p.Value == ageCategory.Value);
                if (age == null)
                    context.MetaKeyValues.Add(ageCategory);
            }
        }

        private static void AddReligion(RpContext context)
        {
            var religions = new List<MetaKeyValue>()
                {
                    new MetaKeyValue()
                        {
                            EntityType = "Candidate",
                            MetaType = "Religion",
                            Value = "Christian"
                        },
                    new MetaKeyValue()
                        {
                            EntityType = "Candidate",
                            MetaType = "Regligion",
                            Value = "Muslim"
                        },
                };
            foreach (var religion in religions)
            {
                var rel = context.MetaKeyValues.FirstOrDefault(p => p.MetaType == religion.MetaType && p.Value == religion.Value);
                if (rel == null)
                    context.MetaKeyValues.Add(religion);
            }
        }

        private static void AddCandidates(RpContext context)
        {

            var candidateList = new List<Candidate>()
                {
                    new Candidate()
                        {
                            FirstName = "James",
                            LastName = "Smith",
                            AgeCategory = new MetaKeyValueHelper().GetMetaKey("Candidate","AgeCategory","18-30"),
                            CurrentSalary = 20000,
                            SalaryExpectation = 40000,
                            Gender = new MetaKeyValueHelper().GetMetaKey("Candidate","Gender","Male"),
                            Religion = new MetaKeyValueHelper().GetMetaKey("Candidate","Religion","Christian"),
                            IsUkEligible = true,

                        },
                         new Candidate()
                        {
                            FirstName = "Peter",
                            LastName = "Downes",
                            AgeCategory = new MetaKeyValueHelper().GetMetaKey("Candidate","AgeCategory","18-30"),
                            CurrentSalary = 20000,
                            SalaryExpectation = 25000,
                            Gender = new MetaKeyValueHelper().GetMetaKey("Candidate","Gender","Male"),
                            Religion = new MetaKeyValueHelper().GetMetaKey("Candidate","Religion","Christian"),
                            IsUkEligible = true,

                        },
                         new Candidate()
                        {
                            FirstName = "Paul",
                            LastName = "West",
                            AgeCategory = new MetaKeyValueHelper().GetMetaKey("Candidate","AgeCategory","31-60"),
                            CurrentSalary = 30000,
                            SalaryExpectation = 40000,
                            Gender = new MetaKeyValueHelper().GetMetaKey("Candidate","Gender","Male"),
                            Religion = new MetaKeyValueHelper().GetMetaKey("Candidate","Religion","Christian"),
                            IsUkEligible = true,

                        },
                         new Candidate()
                        {
                            FirstName = "Laura",
                            LastName = "Davis",
                            AgeCategory = new MetaKeyValueHelper().GetMetaKey("Candidate","AgeCategory","31-60"),
                            CurrentSalary = 60000,
                            SalaryExpectation = 70000,
                            Gender = new MetaKeyValueHelper().GetMetaKey("Candidate","Gender","Female"),
                            Religion = new MetaKeyValueHelper().GetMetaKey("Candidate","Religion","Christian"),
                            IsUkEligible = true,

                        },
                        new Candidate()
                        {
                            FirstName = "Amy",
                            LastName = "Stevenson",
                            AgeCategory = new MetaKeyValueHelper().GetMetaKey("Candidate","AgeCategory","18-30"),
                            CurrentSalary = 60000,
                            SalaryExpectation = 70000,
                            Gender = new MetaKeyValueHelper().GetMetaKey("Candidate","Gender","Female"),
                            Religion = new MetaKeyValueHelper().GetMetaKey("Candidate","Religion","Christian"),
                            IsUkEligible = true,

                        },new Candidate()
                        {
                            FirstName = "Amy",
                            LastName = "Robinson",
                            AgeCategory = new MetaKeyValueHelper().GetMetaKey("Candidate","AgeCategory","18-30"),
                            CurrentSalary = 60000,
                            SalaryExpectation = 70000,
                            Gender = new MetaKeyValueHelper().GetMetaKey("Candidate","Gender","Female"),
                            Religion = new MetaKeyValueHelper().GetMetaKey("Candidate","Religion","Christian"),
                            IsUkEligible = true,

                        },new Candidate()
                        {
                            FirstName = "David",
                            LastName = "Stevenson",
                            AgeCategory = new MetaKeyValueHelper().GetMetaKey("Candidate","AgeCategory","18-30"),
                            CurrentSalary = 60000,
                            SalaryExpectation = 70000,
                            Gender = new MetaKeyValueHelper().GetMetaKey("Candidate","Gender","Male"),
                            Religion = new MetaKeyValueHelper().GetMetaKey("Candidate","Religion","Christian"),
                            IsUkEligible = true,

                        },



                };
            foreach (var candidate in candidateList)
            {
                var exisitingCandidate = context.Candidates.FirstOrDefault(p => p.FirstName == candidate.FirstName && p.LastName == candidate.LastName);
                if (exisitingCandidate == null)
                    context.Candidates.Add(candidate);
            }
        }

        private static void AddVacancyTypes(RpContext context)
        {
            var vacancytypes = new List<VacancyType>()
                {
                    new VacancyType()
                        {
                            Name = "Solicitor",
                            Description = "Solicitor",
                            ParentVacancyTypeId = 0
                        },
                         new VacancyType()
                        {
                            Name = "Legal Secretary",
                            Description = "Legal Secretary",
                            ParentVacancyTypeId = 0
                        },
                         new VacancyType()
                        {
                            Name = "Paralegal",
                            Description = "Paralegal",
                            ParentVacancyTypeId = 0
                        },
                        new VacancyType()
                        {
                            Name = "Case Worker",
                            Description = "Case Worker",
                            ParentVacancyTypeId = 0
                        },
                    
                };
            foreach (var vacancyType in vacancytypes)
            {
                var vac = context.VacancyTypes.FirstOrDefault(p => p.Name == vacancyType.Name && p.ParentVacancyTypeId == vacancyType.ParentVacancyTypeId );
                if (vac == null)
                    context.VacancyTypes.Add(vacancyType);
            }
            context.SaveChanges();
            //child vacancies
            var childVacancies = new List<VacancyType>()
                {
                    new VacancyType()
                        {
                            Name = "Agriculture",
                            Description = "Agriculture",
                            ParentVacancyTypeId = context.VacancyTypes.FirstOrDefault(o => o.Name == "Solicitor").VacancyTypeId
                        },
                        // new VacancyType()
                        //{
                        //    Name = "Residential Property",
                        //    Description = "Residential Property",
                        //    ParentVacancyTypeId = context.VacancyTypes.FirstOrDefault(o => o.Name == "Solicitor").VacancyTypeId
                        //},
                        //new VacancyType()
                        //{
                        //    Name = "Agriculture",
                        //    Description = "Agriculture",
                        //    ParentVacancyTypeId = context.VacancyTypes.FirstOrDefault(o => o.Name == "Paralegal").VacancyTypeId
                        //},
                        // new VacancyType()
                        //{
                        //    Name = "Residential Property",
                        //    Description = "Residential Property",
                        //    ParentVacancyTypeId = context.VacancyTypes.FirstOrDefault(o => o.Name == "Paralegal").VacancyTypeId
                        //},
                };
            foreach (var vacancyType in childVacancies)
            {
                var vac = context.VacancyTypes.FirstOrDefault(p => p.Name == vacancyType.Name && p.ParentVacancyTypeId == vacancyType.ParentVacancyTypeId);
                if (vac == null)
                    context.VacancyTypes.Add(vacancyType);
            }


        }

        private static void AddRating(RpContext context)
        {
            var ratings = new List<MetaKeyValue>()
                {
                    new MetaKeyValue()
                        {
                            EntityType = "RecruitmentCompany",
                            MetaType = "Rating",
                            Value = "Top"
                        },
                    new MetaKeyValue()
                        {
                            EntityType = "RecruitmentCompany",
                            MetaType = "Rating",
                            Value = "Lower"
                        },
                };
            foreach (var rating in ratings)
            {
                var rat = context.MetaKeyValues.FirstOrDefault(p => p.MetaType == rating.MetaType && p.Value == rating.Value);
                if (rat == null)
                    context.MetaKeyValues.Add(rating);
            }
        }

        private static void AddRecruitmentCompanies(RpContext context)
        {
            var recruitmentCompanyList = new List<RecruitmentCompany>()
                {
                    new RecruitmentCompany()
                        {
                            CompanyName = "RecruitmentComp1",
                            LogoUrl = "http://erringtonlegal.co.uk/wp-content/uploads/2013/02/Logo400.png",
                            Address1 = "1 Regent Street",
                            City = "Cambridge",
                            County = "Cambridgeshire",
                            Postcode = "CB1 1AA",
                            EmailAddress = "test@RecruitmentCompany1.com",
                            Rating = context.MetaKeyValues.FirstOrDefault(p => p.MetaType == "Rating" && p.Value == "Top" && p.EntityType == "RecruitmentCompany"),
                            Telephone = "01223 111 111"
                        },
                };
            foreach (var recruitmentCompany in recruitmentCompanyList)
            {
                var recCompany = context.RecruitmentCompanies.FirstOrDefault(p => p.CompanyName == recruitmentCompany.CompanyName);
                if (recCompany == null)
                    context.RecruitmentCompanies.Add(recruitmentCompany);
            }
            
        }

        private static void AddRecruiters(RpContext context)
        {
            var recruitmentUsers = new List<RecruitmentUser>()
                {
                    new RecruitmentUser()
                        {
                           RecruitmentCompany = context.RecruitmentCompanies.FirstOrDefault(o => o.CompanyName == "RecruitmentComp1" ),
                           UserProfile =  context.UserProfile.FirstOrDefault(o => o.UserName == "eleanor@erringtonLegal.co.uk")
                        },
                };
            foreach (var recruitmentUser in recruitmentUsers)
            {
                var recUser = context.RecruitmentUsers.FirstOrDefault(p => p.UserProfile.UserId == recruitmentUser.UserProfile.UserId);
                if (recUser == null)
                {
                    context.RecruitmentUsers.Add(recruitmentUser);
                    
                }
            }

        }
    }
}
