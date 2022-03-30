﻿#nullable disable
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
                // Reinitialize and seed some data. In a production environment you would probably want to use migrations instead.
                _created = true;
                Database.EnsureDeleted();
                Database.EnsureCreated();
                MapItems.Add(new MapItem() { Name = "Järntorget", Latitude = 57.699871m, Longitude = 11.952903m, StreetName = "Järntorget", StreetNumber = "0", PostalCode = "41304", City = "Göteborg" });
                MapItems.Add(new MapItem() { Name = "Liseberg", Latitude = 57.695011m, Longitude = 11.992199m, StreetName = "Örgrytevägen", StreetNumber = "5", PostalCode = "40222", City = "Göteborg" });
                MapItems.Add(new MapItem() { Name = "Göteborgs Centralstation", Latitude = 57.709284m, Longitude = 11.972801m, StreetName = "Drottningtorget", StreetNumber = "5", PostalCode = "41103", City = "Göteborg" });
                SaveChanges();
            }
}

        public DbSet<LeafletMapTest.Models.MapItem> MapItems { get; set; }
    }
}
