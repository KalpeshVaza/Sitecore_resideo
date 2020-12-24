using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Resideo.Models
{
    public class Logo
    {
        public string LogoImageUrl { get; set; }
        public List<String> LogoDescriptionText { get; set; }
        public string LogoDownloadLink { get; set; }
        public string ProductDownloadLinkText { get; set; }
    }
}