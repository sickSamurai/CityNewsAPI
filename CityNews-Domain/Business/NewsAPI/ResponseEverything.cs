 using System;
using System.Collections.Generic;

namespace Domain.Business.NewsApi
{
    public class ResponseEverything
    {
        public string Status { get; set; }
        public int TotalResults { get; set; }
        public List<Articles> Articles { get; set; }
    }

    public class Articles
    {
        public SourceObject Source { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string UrlToImage { get; set; }
        public DateTime PublishedAt { get; set; }
        public string Content { get; set; }
    }

    public class SourceObject
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
