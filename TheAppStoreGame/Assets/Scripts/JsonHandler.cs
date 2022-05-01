
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
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("creator")]
        public string Creator { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

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

    //ACM has a list of strings for the scores for the codes
    public partial class Acm
    {
        [JsonProperty("positiveCodeScores")]
        public int[] PositiveCodeScores { get; set; }

        [JsonProperty("negativeCodeScores")]
        public int[] NegativeCodeScores { get; set; }

        [JsonProperty("positiveExplanations", NullValueHandling = NullValueHandling.Ignore)]
        public string[][] PositiveExplanations { get; set; }

        [JsonProperty("negativeExplanations", NullValueHandling = NullValueHandling.Ignore)]
        public string[][] NegativeExplanations { get; set; }
    }

    //Consequence has the textToDisplay and displayLocation
    public partial class Consequence
    {
        [JsonProperty("header")]
        public string Header { get; set; }

        [JsonProperty("textToDisplay")]
        public string TextToDisplay { get; set; }

        [JsonProperty("sender")]
        public string Sender { get; set; }

        [JsonProperty("displayLocation")]
        public int DisplayLocation { get; set; }
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
