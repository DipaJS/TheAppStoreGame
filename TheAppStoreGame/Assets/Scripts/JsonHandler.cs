
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using JsonHandler;
//
//    var apps = Apps.FromJson(jsonString);

namespace JsonHandler
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Apps
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("pricing")]
        public string Pricing { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("images")]
        public string[] Images { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("accepted")]
        public Ted Accepted { get; set; }

        [JsonProperty("rejected")]
        public Ted Rejected { get; set; }
    }

    public partial class Ted
    {
        [JsonProperty("consequences")]
        public Consequence[] Consequences { get; set; }

        [JsonProperty("ACM")]
        public Acm Acm { get; set; }
    }

    public partial class Acm
    {
        [JsonProperty("codesHonored")]
        public object[] CodesHonored { get; set; }

        [JsonProperty("codesDishonored")]
        public object[] CodesDishonored { get; set; }
    }

    public partial class Consequence
    {
        [JsonProperty("textToDisplay")]
        public string TextToDisplay { get; set; }

        [JsonProperty("displayLocation")]
        public long DisplayLocation { get; set; }
    }

    public partial class Apps
    {
        public static Apps[] FromJson(string json) => JsonConvert.DeserializeObject<Apps[]>(json, JsonHandler.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Apps[] self) => JsonConvert.SerializeObject(self, JsonHandler.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
