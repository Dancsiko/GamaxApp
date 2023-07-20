using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GamaxApp.Models;

namespace GamaxApp.Data
{
    public class GamaxAppContext : DbContext
    {
        public GamaxAppContext (DbContextOptions<GamaxAppContext> options)
            : base(options)
        {
        }

        public DbSet<GamaxApp.Models.User> User { get; set; } = default!;
    }
}
