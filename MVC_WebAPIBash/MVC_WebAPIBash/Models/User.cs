using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVC_WebAPIBash.Models
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Tweet> Tweets { get; set; }
        public virtual IList<User> Followers { get; set; }
        public virtual IList<User> Following { get; set; }
    }
}