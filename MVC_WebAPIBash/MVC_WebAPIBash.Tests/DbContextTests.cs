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
    }
}
