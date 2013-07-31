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
          

            context.SaveChanges();
        }
    }
}
