using Sitecore.Diagnostics;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace Sitecore.Resideo.Controllers
{
    public class LoginController : ApiController
    {
        public HttpResponseMessage Authenticate(FormDataCollection formcollection)
        {
            try
            {
                var user = Sitecore.Security.Authentication.AuthenticationManager.BuildVirtualUser(Context.Domain.Name + @"\" + formcollection["email"], true);
                if (user != null)
                {
                    var domainRole = $"{Context.Domain}";
                    if (Sitecore.Security.Accounts.Role.Exists(domainRole))
                    {
                        user.Roles.Add(Sitecore.Security.Accounts.Role.FromName(domainRole));
                    }
                    user.Profile.FullName = formcollection["name"];
                    user.Profile.SetCustomProperty("Id", formcollection["sub"]);
                    user.Profile.Save();
                    Security.Authentication.AuthenticationManager.LoginVirtualUser(user);
                }
                return Request.CreateResponse(HttpStatusCode.OK, Context.User.Name.ToString());
            }
            catch (Exception ex)
            {
                Log.Error($"{typeof(ProductsController)}::{nameof(Authenticate)}", ex, Context.User);
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, "Something Went Wrong.");
            }
        }
    }
}
