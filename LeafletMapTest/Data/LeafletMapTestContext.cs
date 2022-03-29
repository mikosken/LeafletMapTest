#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LeafletMapTest.Models;

namespace LeafletMapTest.Data
{
    public class LeafletMapTestContext : DbContext
    {
        public LeafletMapTestContext (DbContextOptions<LeafletMapTestContext> options)
            : base(options)
        {
        }

        public DbSet<LeafletMapTest.Models.MapItem> MapItem { get; set; }
    }
}
