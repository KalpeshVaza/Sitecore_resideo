using Sitecore.Configuration;
using Sitecore.Data;

namespace Sitecore.Resideo
{
    public class Templates
    {
        public struct Product
        {
            public static readonly ID ID = new ID("{48EF7CDF-DB48-4D87-A7A5-4A9EE9E129AD}");
            public struct Fields
            {
                public static readonly ID ProductTitle = new ID("{9728D366-9677-4284-8A85-C129A8C023FD}");
                public static readonly ID ProductDescription = new ID("{99ACE475-4B13-4BF9-A1E9-AACC2F636A07}");
                public static readonly ID ProductImage = new ID("{CCEF1E87-F94C-4D75-8E0F-090F175F7924}");
                public static readonly ID ProductLink = new ID("{F9863BB0-CC60-4613-A48C-BFB070C6FE0C}");
            }
        }

        public struct Logo
        {
            public static readonly ID ID = new ID("{CBF510FD-91C8-4EFB-8101-BCCA18D7580C}");
            public struct Fields
            {
                public static readonly ID LogoImage = new ID("{AA633D0D-9567-41E3-B67F-620A3A4759E7}");
                public static readonly ID LogoDescription = new ID("{021E62AD-E5CA-4D21-9A59-25727B84D901}");
                public static readonly ID LogoImageDownloadLink = new ID("{BA6FC3E0-5978-4CC3-9C70-031483DF694D}");
                public static readonly ID LogoDownloadText = new ID("{6F29FF15-0062-428B-9437-09D25616C3C4}");
            }
        }

        public struct LogoDescription
        {
            public static readonly ID ID = new ID("{E1C05EC3-8617-490B-BDAA-2F101AB2B488}");
            public struct Fields
            {
                public static readonly ID DescriptionText = new ID("{C62222AC-ADDD-4718-AD23-77623F9FE6F6}");
            }
        }
    }
}