using InvenTID_App;
using InvenTID_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;


public  static class AppSession
    {
        /// <summary>
        /// Application version.
        /// </summary>
        /// <returns></returns>
        public static string GetAppVersion()
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            var buildDateTime = new DateTime(2000, 1, 1)
                .AddDays(version.Build) // days since 1 January 2000
                .AddSeconds(2 * version.Revision);
            return string.Format("{0}.{1} from {2:yyyy/MM/dd HH:mm:ss}", version.Major, version.Minor, buildDateTime);
        }

        /// <summary>
        /// Member profile which is kept in the session object.
        /// </summary>
        public static ApplicationUser Profile
        {
            get
            {

                if (HttpContext.Current != null && HttpContext.Current.Session != null)
                {
                    if (HttpContext.Current.User != null && HttpContext.Current.User.Identity != null && HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        ApplicationUser _Profile = (ApplicationUser)HttpContext.Current.Session["UserProfile"];
                        if (_Profile != null)
                            return _Profile;
                        else
                        {

                            ApplicationUser _Member = ApplicationUserManager.GetUserByName(HttpContext.Current.User.Identity.Name);
                            HttpContext.Current.Session["UserProfile"] = _Member;
                            return _Member;
                        }
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
        }
    }
