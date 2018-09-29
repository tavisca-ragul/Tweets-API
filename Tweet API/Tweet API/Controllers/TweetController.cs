using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aerospike.Client;
using Data_Dump_Tool;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tweet_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetController : ControllerBase
    {
        AerospikeClient aerospikeClient = new AerospikeClient("18.235.70.103", 3000);
        string nameSpace = "AirEngine";
        string setName = "ragulKrishnan";

        [HttpGet]
        public ActionResult GetTweets(string ids)
        {
            List<Tweet> tweetData = new List<Tweet>();
            foreach (var tweetID in ids.Split(','))
            {
                Record record = aerospikeClient.Get(new BatchPolicy(), new Key(nameSpace, setName, tweetID));
                Tweet tweet = new Tweet();
                if (record == null)
                    return BadRequest($"Tweet Id : {tweetID} is not found");
                tweet.first_name = record.GetString("first_name");
                tweet.last_name = record.GetString("last_name");
                tweet.screenName = record.GetString("screenName");
                tweet.text = record.GetString("text");
                tweet.favoriteCount = record.GetInt("favoriteCount");
                tweet.text = record.GetString("text");
                tweet.created = DateTime.Parse(record.GetString("created"));
                tweet.id = record.GetString("id");
                tweet.text = record.GetString("text");
                tweet.retweetCount = record.GetInt("retweetCount");
                tweet.timestamp = DateTime.Parse(record.GetString("timestamp"));
                tweetData.Add(tweet);
            }
            return Ok(tweetData);
        }

        [HttpDelete]
        public ActionResult DeleteTweet(string id)
        {
            aerospikeClient.Delete(new WritePolicy(), new Key(nameSpace, setName, id));
            return Ok("Tweet is deleted");
        }

        [HttpPut]
        public ActionResult PutTweet(int id, Tweet tweet)
        {
            aerospikeClient.Put(new WritePolicy(), new Key(nameSpace, setName, id),
                    new Bin[] { new Bin("text", tweet.text),
                        new Bin("favoriteCount", tweet.favoriteCount),
                        new Bin("created", tweet.created.ToString()),
                        new Bin("screenName", tweet.screenName),
                        new Bin("retweetCount", tweet.retweetCount),
                        new Bin("timestamp", tweet.timestamp.ToString()),
                        new Bin("last_name", tweet.last_name),
                        new Bin("first_name", tweet.first_name)
                    });
            return Ok("Tweet is Updated");
        }

    }
}