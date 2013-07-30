using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVC_WebAPIBash.Models
{
    public class Tweet
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Body { get; set; }
        public virtual User User { get; set; }
        public virtual int UserId { get; set; }
        public virtual DateTimeOffset Published { get; set; }
    }
}
