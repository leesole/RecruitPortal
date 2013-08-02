using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELegal.RecruitmentPortal.Framework.Configuration;
using ELegal.RecruitmentPortal.Framework.Initial;
using ELegal.RecruitmentPortal.Model;

namespace ELegal.RecruitmentPortal.Framework.DataContext
{
    public class RpContext : DbContext
    {
        static RpContext()
        {
            Database.SetInitializer(new RpDatabaseInitialiser());
        }
        public RpContext() : base("DefaultConnection")
        {
            
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new RoleConfiguration());
        }

        public override int SaveChanges()
        {
            ApplyAudit();
            return base.SaveChanges();
        }



        public void ApplyAudit()
        {
            foreach (var entry in this.ChangeTracker.Entries()
                                      .Where(
                                          e => e.Entity is IRpAudit &&
                                               (e.State == EntityState.Added) ||
                                               (e.State == EntityState.Modified)))
            {
                IRpAudit e = (IRpAudit)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    e.CreatedDate = DateTime.UtcNow;
                }

                e.UpdatedDate = DateTime.UtcNow;
            }
        }

        public DbSet<RecruitmentCompany> RecruitmentCompanies { get; set; }
        public DbSet<RecruitmentUser> RecruitmentUsers { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<MetaKeyValue> MetaKeyValues { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<RecruitmentCompanyRate> RecruitmentCompanyRates { get; set; }
        public DbSet<VacancyType> VacancyTypes { get; set; } 
        



    }
}
