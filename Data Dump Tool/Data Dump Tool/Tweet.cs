using System;

namespace Data_Dump_Tool
{
    class Tweet
    {
        public string text { get; set; }
        public bool favorited { get; set; }
        public int favoriteCount { get; set; }
        public string replyToSN { get; set; }
        public DateTime created{ get; set; }
        public bool truncated { get; set; }
        public string replyToSID { get; set; }
        public string id { get; set; }
        public string replyToUID { get; set; }
        public string statusSource { get; set; }
        public string screenName { get; set; }
        public int retweetCount { get; set; }
        public bool isRetweet { get; set; }
        public bool retweeted { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public DateTime timestamp { get; set; }
        public DateTime us_timestamp { get; set; }
        public DateTime date { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public DateTime birthday { get; set; }
        public char gender { get; set; }
        public string type { get; set; }
        public string state { get; set; }
        public string district { get; set; }
        public string party { get; set; }
        public string url { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string contact_form { get; set; }
        public string rss_url { get; set; }
        public string twitter { get; set; }
    }
}