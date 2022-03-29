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
        // This is for testing, so (re)create database every time context is instantiated first time.
        private static bool _created = false;
        public LeafletMapTestContext (DbContextOptions<LeafletMapTestContext> options)
            : base(options)
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }

        public DbSet<LeafletMapTest.Models.MapItem> MapItem { get; set; }
    }
}
