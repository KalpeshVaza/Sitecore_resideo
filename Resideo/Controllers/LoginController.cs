using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sitecore.Diagnostics;
using Sitecore.Resideo.Models;
using Sitecore.Services.Infrastructure.Web.Http;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Sitecore.Resideo.Controllers
{
    [EnableCors("*", "*", "*")]
    public class LoginController : ServicesApiController
    {
        public HttpResponseMessage Authenticate(JObject jsonResult)
        {
            try
            {
                var data = JsonConvert.DeserializeObject<LoginDetail>(jsonResult.ToString());
                if (!string.IsNullOrEmpty(Context.User?.Name?.ToString()) && Context.User?.Profile?.FullName?.ToString().ToLowerInvariant() != data.Email)
                {
                    var user = Sitecore.Security.Authentication.AuthenticationManager.BuildVirtualUser(Context.Domain.Name + @"\" + data?.Email, true);
                    if (user != null)
                    {
                        var domainRole = $"{Context.Domain}";
                        if (Sitecore.Security.Accounts.Role.Exists(domainRole))
                        {
                            user.Roles.Add(Sitecore.Security.Accounts.Role.FromName(domainRole));
                        }
                        user.Profile.FullName = data?.Name;
                        user.Profile.SetCustomProperty("Id", data?.Id);
                        user.Profile.Save();
                        Security.Authentication.AuthenticationManager.LoginVirtualUser(user);
                    }
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
