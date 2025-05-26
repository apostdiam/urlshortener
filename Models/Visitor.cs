using System;
using System.Text.Json.Serialization;

namespace URL_Shortener.Models
{
    public class Visitor
    {
        [JsonPropertyName("VisitorId")]
        public int VisitorId { get; set; }

      
    }
}
