using Network.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Network.Domain
{
    public class DbContext
    {
        public IList<User> Users { get; set; }

        public IList<Post> Posts { get; set; }

    }
}
