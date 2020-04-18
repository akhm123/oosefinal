
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DocumentMangement.Models
{
    class DbContextclass:DbContext
    {
        public DbContextclass(): base("name=constring")
        {

        }


        public virtual DbSet<User> users { get; set; }
        public virtual DbSet<Document> document { get; set; }

    }
}
