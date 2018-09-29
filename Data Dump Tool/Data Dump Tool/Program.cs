using Aerospike.Client;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;

namespace Data_Dump_Tool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string path = @"C:\Users\rkrishnan\source\repos\Data Dump Tool\Data Dump Tool\tweets1.csv";
            var aerospikeClient = new AerospikeClient("18.235.70.103", 3000);
            string nameSpace = "AirEngine";
            string setName = "ragulKrishnan";
            StreamReader sr = new StreamReader(path);
            CsvReader csvread = new CsvReader(sr);
            IEnumerable<Tweet> records = csvread.GetRecords<Tweet>();
            foreach (var record in records)
            {
                var key = new Key(nameSpace,setName,record.id);
                aerospikeClient.Put(new WritePolicy(), key, 
                    new Bin[] { new Bin("text", record.text),
                        new Bin("favorited", record.favorited),
                        new Bin("favoriteCount", record.favoriteCount),
                        new Bin("replyToSN", record.replyToSN),
                        new Bin("created", record.created.ToString()),
                        new Bin("truncated", record.truncated),
                        new Bin("replyToSID", record.replyToSID),
                        new Bin("id", record.id),
                        new Bin("replyToUID", record.replyToUID),
                        new Bin("statusSource", record.statusSource),
                        new Bin("screenName", record.screenName),
                        new Bin("retweetCount", record.retweetCount),
                        new Bin("isRetweet", record.isRetweet),
                        new Bin("retweeted", record.retweeted),
                        new Bin("longitude", record.longitude),
                        new Bin("latitude", record.latitude),
                        new Bin("timestamp", record.timestamp.ToString()),
                        new Bin("us_timestamp", record.us_timestamp.ToString()),
                        new Bin("date", record.date.ToString()),
                        new Bin("last_name", record.last_name),
                        new Bin("first_name", record.first_name),
                        new Bin("birthday", record.birthday.ToString()),
                        new Bin("gender", record.gender),
                        new Bin("type", record.type),
                        new Bin("state", record.state),
                        new Bin("district", record.district),
                        new Bin("party", record.party),
                        new Bin("url", record.url),
                        new Bin("address", record.address),
                        new Bin("phone", record.phone),
                        new Bin("contact_form", record.contact_form),
                        new Bin("rss_url", record.rss_url),
                        new Bin("twitter", record.twitter)
                    });
            }
            sr.Close();
        }
    }
}