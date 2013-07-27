using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ELegal.RecruitmentPortal.Framework.DataContext;

namespace ELegal.RecruitmentPortal.Web.Controllers
{
    public class AuthenticatedController : Controller
    {
        private Model.UserProfile _authenticatedUser;

        public Model.UserProfile AuthenticatedUser
        {
            get
            {
                if (_authenticatedUser == null)
                {
                    // get the profile
                    if (User != null && User.Identity != null && User.Identity.IsAuthenticated)
                    {
                        _authenticatedUser = GetCurrentUser();
                    }
                }
                return _authenticatedUser;

            }
            set { _authenticatedUser = value; }
        }

        #region Events

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Ensure ASP.NET Simple Membership is initialized only once per app start
            //LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
            base.OnActionExecuting(filterContext);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            SetViewBagDefaultProperties();
            base.OnActionExecuted(filterContext);
        }

        #endregion


        #region Method

        private Model.UserProfile GetCurrentUser()
        {
            var context = new RpContext();
            MembershipUser user = Membership.GetUser();
            if (user != null)
            {
                var rpuser = context.UserProfiles.SingleOrDefault(u => u.UserId == (int)user.ProviderUserKey);
                if (rpuser != null)
                {
                    return rpuser;
                }
            }

            return null;
        }

        private void SetViewBagDefaultProperties()
        {
            if (this.AuthenticatedUser != null)
            {
                ViewBag.AuthenticatedUserName = this.AuthenticatedUser.UserName;
            }
        }

        #endregion

    }


}
