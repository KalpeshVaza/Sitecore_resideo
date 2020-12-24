using Sitecore.Data.Fields;
using Sitecore.Diagnostics;
using Sitecore.Resideo.Models;
using Sitecore.Resources.Media;
using Sitecore.Services.Infrastructure.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Sitecore.Resideo.Controllers
{
    [EnableCors("http://localhost:3000", "*", "*")]
    public class LogosController : ServicesApiController
    {
        public HttpResponseMessage GetLogos()
        {
            try
            {
                var logoFolder = Sitecore.Context.Database.GetItem(Constants.LogoFolder);
                var items = logoFolder?.GetChildren()?.Where(w => w?.TemplateID == Constants.LogoTemplateId)?.ToList();
                List<Logo> logos = new List<Logo>();
                if (items != null && items.Count > 0)
                {
                    foreach (var item in items)
                    {
                        var fileField = (FileField)item.Fields[Templates.Logo.Fields.LogoImageDownloadLink];
                        var imageField = (ImageField)item.Fields[Templates.Logo.Fields.LogoImage];
                        Logo logo = new Logo();
                        var descriptions = new MultilistField(item.Fields[Templates.Logo.Fields.LogoDescription]).GetItems();
                        if (descriptions != null && descriptions.Count() > 0)
                        {
                            logo.LogoDescriptionText = new List<string>();
                            foreach (var description in descriptions)
                            {
                                var data = description.Fields[Templates.LogoDescription.Fields.DescriptionText].Value;
                                logo.LogoDescriptionText.Add(data);
                            }
                        }
                        logo.LogoImageUrl = MediaManager.GetMediaUrl(imageField?.MediaItem, new MediaUrlOptions { AlwaysIncludeServerUrl = true });
                        logo.ProductDownloadLinkText = item.Fields[Templates.Logo.Fields.LogoDownloadText].Value;
                        logo.LogoDownloadLink = MediaManager.GetMediaUrl(fileField?.MediaItem, new MediaUrlOptions { AlwaysIncludeServerUrl = true });
                        logos.Add(logo);
                    }
                }
                return Request.CreateResponse(HttpStatusCode.OK, logos);
            }
            catch (Exception ex)
            {
                Log.Error($"{typeof(ProductsController)}::{nameof(GetLogos)}", ex, Context.User);
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, "Something Went Wrong.");
            }
        }
    }
}
