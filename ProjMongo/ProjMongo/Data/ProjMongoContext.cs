using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjMongo.Model;

namespace ProjMongo.Data
{
    public class ProjMongoContext : DbContext
    {
        public ProjMongoContext (DbContextOptions<ProjMongoContext> options)
            : base(options)
        {
        }

        public DbSet<ProjMongo.Model.Person> Person { get; set; }
    }
}
