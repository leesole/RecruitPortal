using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using Microsoft.Web.WebPages.OAuth;
using ELegal.RecruitmentPortal.Web.Models;
using WebMatrix.WebData;

namespace ELegal.RecruitmentPortal.Web
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            //OAuthWebSecurity.RegisterTwitterClient(
            //    consumerKey: "",
            //    consumerSecret: "");

            //OAuthWebSecurity.RegisterFacebookClient(
            //    appId: "",
            //    appSecret: "");

            //OAuthWebSecurity.RegisterGoogleClient();
        }

        public static void InitWebSec()
        {
            if (!WebSecurity.Initialized)
                WebSecurity.InitializeDatabaseConnection("DefaultConnection",
                    "UserProfile", "UserId", "UserName", autoCreateTables: true);

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

    }
}
