using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;
using ELegal.RecruitmentPortal.Web.Models;

namespace ELegal.RecruitmentPortal.Web.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Ensure ASP.NET Simple Membership is initialized only once per app start
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                Database.SetInitializer<UsersContext>(null);

                try
                {
                    using (var context = new UsersContext())
                    {
                        if (!context.Database.Exists())
                        {
                            // Create the SimpleMembership database without Entity Framework migration schema
                            ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                        }
                    }


                    WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
                    
                    #region Add Various Roles
                    if (!Roles.RoleExists("Administration"))
                        Roles.CreateRole("Administration");

                    if (!Roles.RoleExists("Recruitment"))
                        Roles.CreateRole("Recruitment");

                    if (!Roles.RoleExists("HR"))
                        Roles.CreateRole("HR");
                    #endregion Add Various Roles

                    #region Add Admin Users
                    if (!WebSecurity.UserExists("mark@markogrady.com"))
                        WebSecurity.CreateUserAndAccount("mark@markogrady.com", "password");

                    if (!Roles.GetRolesForUser("mark@markogrady.com").Contains("Administration"))
                        Roles.AddUsersToRoles(new[] { "mark@markogrady.com" }, new[] { "Administration" });
                    #endregion Add Admin Users

                    #region Add HR User
                    if (!WebSecurity.UserExists("mark@hr.com"))
                        WebSecurity.CreateUserAndAccount("mark@hr.com", "password");

                    if (!Roles.GetRolesForUser("mark@hr.com").Contains("HR"))
                        Roles.AddUsersToRoles(new[] { "mark@hr.com" }, new[] { "HR" });
                    #endregion Add HR Users

                    #region Add HR User
                    if (!WebSecurity.UserExists("eleanor@erringtonLegal.co.uk"))
                        WebSecurity.CreateUserAndAccount("eleanor@erringtonLegal.co.uk", "password");

                    if (!Roles.GetRolesForUser("eleanor@erringtonLegal.co.uk").Contains("Recruitment"))
                        Roles.AddUsersToRoles(new[] { "eleanor@erringtonLegal.co.uk" }, new[] { "Recruitment" });
                    #endregion Add HR Users

                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }
            }
        }
    }
}
