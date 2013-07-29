using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_WebAPIBash.Models
{
    public class TwittrContext : DbContext
    {
        public IDbSet<User> Users { get; set; }
        public IDbSet<Tweet> Tweets { get; set; }
    }
}