using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace URL_Shortener.Models
{
    public class URLLinks
    {
        public int Id { get; set; }

        [Required]
        public string OriginalUrl { get; set; }

        [Required]
        public string ShortenedUrlPrefix { get; set; } = "https://localhost";

        public string ShortenedUrl { get; set; } = null!;      

        public DateTime ConvertedAt { get; set; } = DateTime.Now;

        public DateTime VisitedAt { get; set; } = DateTime.MinValue;

        public System.Net.IPAddress VisitorsIpAddress { get; set; } = null!;

        public string VisitorsUserAgent { get; set; } = null!;

        public int TimesVisited { get; set; } = 0!;

        //public List<Visitor> Visitors { get; set; } = new List<Visitor>();
    }    
}
