using System;
using System.Linq;
using ELegal.RecruitmentPortal.Framework.DataContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ELegal.RecruitmentPortal.Web.Tests.Model
{
    [TestClass]
    public class RecruitmentCompanyTest
    {
        [TestMethod]
        public void CheckTheSeedCompany()
        {
            using (var context = new RpContext())
            {
                var companies = from rc in context.RecruitmentCompanies
                                select rc;

                Assert.IsTrue(companies.Any());

            }
        }
    }
}
