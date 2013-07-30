using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_WebAPIBash.Models
{
    public class TwittrContext : DbContext
    {
        static TwittrContext()
        {
            Database.SetInitializer<TwittrContext>(new TwittrContextInitializer());
        }

        private class TwittrContextInitializer : DropCreateDatabaseAlways<TwittrContext>
        {
            protected override void Seed(TwittrContext context)
            {
                User luke = context.Users.Create();
                luke.Name = "Luke Waters";
                luke.Tweets = new List<Tweet>();
                luke.Following = new List<User>();
                Tweet lukesTweet = context.Tweets.Create();
                lukesTweet.Body = "The first tweet from the amazing luke waters";
                lukesTweet.Published = DateTimeOffset.Now.AddDays(-8);
                luke.Tweets.Add(lukesTweet);

                User javier = new User();
                javier.Name = "Javier";
                javier.Tweets = new List<Tweet>();
                Tweet javiersTweet = context.Tweets.Create();
                javiersTweet.Published = DateTimeOffset.Now.AddDays(-5);
                Tweet javiersSecondTweet = context.Tweets.Create();
                javiersSecondTweet.Body = "Amazing bug bash!";
                javiersSecondTweet.Published = DateTimeOffset.Now.AddDays(-3);
                javiersTweet.Body = "Hello Twittr!!";
                javier.Tweets.Add(javiersTweet);

                luke.Following.Add(javier);

                context.Users.Add(javier);
                context.Users.Add(luke);
            }
        }

        public IDbSet<User> Users { get; set; }
        public IDbSet<Tweet> Tweets { get; set; }
    }
}