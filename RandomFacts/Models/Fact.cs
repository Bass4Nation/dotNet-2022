﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using RandomFacts.Models;
//
//    var fact = Fact.FromJson(jsonString);

namespace RandomFacts.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Fact
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public partial class Fact
    {
        public static List<Fact> FromJson(string json) => JsonConvert.DeserializeObject<List<Fact>>(json, RandomFacts.Models.Converter.Settings);
    }

    public partial class Fact
    {
        public static Fact FromSoloJson(string json) => JsonConvert.DeserializeObject<Fact>(json, RandomFacts.Models.Converter.Settings);
    }

    public static class FactsSerialize
    {
        public static string ToJson(this List<Fact> self) => JsonConvert.SerializeObject(self, RandomFacts.Models.Converter.Settings);
        public static string ToSoloJson(this Fact self) => JsonConvert.SerializeObject(self, RandomFacts.Models.Converter.Settings);

    }
}