using System.Collections.Generic;
using System.Net.Http;
using RW.Domain.Models;
using CodeHollow.FeedReader;

namespace RW.Domain
{
    public class RssFeedReader
    {
        private string[] _Feeds;

        public RssFeedReader(string[] Feeds) {
            _Feeds = Feeds;
        }

        public List<rssfeed> GetFeeds() {
            return new List<rssfeed>();
        }

        public List<article> GetArticles() {
            return new List<article>();
        }
    }
}
