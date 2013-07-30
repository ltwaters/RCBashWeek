using MVC_WebAPIBash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MVC_WebAPIBash.Tests
{
    public class DbContextTests
    {
        [Fact]
        public void CanBuildDbContext()
        {
            using (TwittrContext context = new TwittrContext())
            {
                Assert.DoesNotThrow(() => context.Users.ToList());
            }
        }

        [Fact]
        public void InitializationIsCorrect()
        {
            using (TwittrContext context = new TwittrContext())
            {
                IList<User> users = context.Users.ToList();
                IList<Tweet> tweets = context.Tweets.ToList();

                Assert.Equal(2, users.Count);
                User javier = Assert.Single(users, u => u.Name == "Javier");
                User luke = Assert.Single(users, u => u.Name == "Luke Waters");
                Assert.Equal(1, javier.Followers.Count);
                Assert.Equal(1, luke.Following.Count);
            }
        }
    }
}
