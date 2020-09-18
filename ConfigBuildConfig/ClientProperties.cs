using System;
using Newtonsoft.Json;

namespace ConfigBuildConfig
{
    public class ClientProperties
    {
        [JsonProperty(PropertyName = "environment")]
        public string Environment { get; set; }
    }
}
