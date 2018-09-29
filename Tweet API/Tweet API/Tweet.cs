using System;

namespace Data_Dump_Tool
{
    public class Tweet
    {
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string screenName { get; set; }
        public string text { get; set; }
        public int favoriteCount { get; set; }
        public DateTime created{ get; set; }
        public string id { get; set; }   
        public int retweetCount { get; set; }
        public DateTime timestamp { get; set; }
    }
}