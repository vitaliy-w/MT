using System;
using System.Web;
using System.Web.Security;

namespace MT.Utility.OtherTools
{
    public static class CustomUtilityExtensions
    {
        /// <summary>
        /// Returns userId encrypted in cookies.
        /// </summary>
        public static string GetUserMailFromFormsAuthentication(this HttpCookieCollection cookies)
        {
            var cookie = cookies[".ASPXAUTH"];
            if (cookie != null)
            {
                var authenticationTicket = FormsAuthentication.Decrypt(cookie.Value);
                if (authenticationTicket != null)
                {
                    string userId = authenticationTicket.Name;
                    return userId;
                }
            }

            throw new Exception("No .AUTHX found");
        }
    }

    
}
