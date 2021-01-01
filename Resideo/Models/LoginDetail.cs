using Newtonsoft.Json;
using System;

namespace Sitecore.Resideo.Models
{
    [Serializable]
    public class LoginDetail
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sub")]
        public string Id { get; set; }
    }
}