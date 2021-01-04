using Sitecore.Configuration;
using Sitecore.Data;

namespace Sitecore.Resideo
{
    public class Templates
    {
        public struct Product
        {
            public static readonly ID ID = new ID("{DA8900FA-FD66-45AA-9D66-C728DBDD0014}");
            public struct Fields
            {
                public static readonly ID ProductTitle = new ID("{6CF0D87B-9315-4703-9639-8DD05AD00DE5}");
                public static readonly ID ProductDescription = new ID("{9930621F-B9BD-4F59-B7DC-3ABC2FB4ABF3}");
                public static readonly ID ProductImage = new ID("{CA263839-4079-4764-BC9D-B52D307F0F77}");
                public static readonly ID ProductLink = new ID("{696B4D7B-5165-4A97-A032-EBA22CA1F948}");
            }
        }

        public struct Logo
        {
            public static readonly ID ID = new ID("{7E476BD7-3BD9-4982-A731-D5A1F564AAD4}");
            public struct Fields
            {
                public static readonly ID LogoImage = new ID("{B693D2D6-E36E-4C96-941A-3835C8E0D906}");
                public static readonly ID LogoDescription = new ID("{AB7652C8-3B4F-4DA9-8708-2ACEF9CE53E8}");
                public static readonly ID LogoImageDownloadLink = new ID("{15ED010C-D0B3-454F-A754-09437D7A9C33}");
                public static readonly ID LogoDownloadText = new ID("{A3C15CBA-C579-48E4-A36B-376A490E8A1B}");
            }
        }

        public struct LogoDescription
        {
            public static readonly ID ID = new ID("{BDDA23D5-72F8-447E-97E2-65A03E897228}");
            public struct Fields
            {
                public static readonly ID DescriptionText = new ID("{C3C522B7-5577-44F3-BED1-CD5B849EAB41}");
            }
        }
    }
}