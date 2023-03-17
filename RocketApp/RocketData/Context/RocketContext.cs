using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RocketDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketData.Context
{
    public class RocketContext : DbContext
    {
        public RocketContext(DbContextOptions options): base(options)
        {}

        public DbSet<Rocket> rockets { get; set; }
    }
}
