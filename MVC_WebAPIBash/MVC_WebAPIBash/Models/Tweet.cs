using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVC_WebAPIBash.Models
{
    public class Tweet
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
