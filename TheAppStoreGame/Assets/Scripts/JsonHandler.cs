
/* 
    To parse this JSON data, add NuGet 'Newtonsoft.Json' (complete for this projekt) then do: 

    using JsonHandler;
    var apps = Apps.FromJson(jsonString); 
*/

namespace JsonHandler
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    //A script for deserializing the json-file where we store our applications and convert them to C#-classes
        //Each class has a public set and get function

    //get and set functions for the Apps-class and its members.  
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
        public Status Accepted { get; set; }

        [JsonProperty("rejected")]
        public Status Rejected { get; set; }

        public bool Status {get; set;}
    }

    //Set either to accepted or rejected in the Apps-class
    //Has a list of consequences and the Acm-class as parameters
    public partial class Status 
    {
        [JsonProperty("consequences")]
        public Consequence[] Consequences { get; set; }

        [JsonProperty("ACM")]
        public Acm Acm { get; set; }
    }

    //Acm has one list for codesHonored and one for codesDishonored
    public partial class Acm
    {
        [JsonProperty("codesHonored")]
        public object[] CodesHonored { get; set; }

        [JsonProperty("codesDishonored")]
        public object[] CodesDishonored { get; set; }
    }

    //Consequence has the textToDisplay and displayLocation
    public partial class Consequence
    {
        [JsonProperty("textToDisplay")]
        public string TextToDisplay { get; set; }

        [JsonProperty("sender")]
        public string Sender { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("displayLocation")]
        public long DisplayLocation { get; set; }
    }

    //Converting the json-string to the corresponding C#-classes
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
