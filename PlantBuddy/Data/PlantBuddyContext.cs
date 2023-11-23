using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlantBuddy.Models;

namespace PlantBuddy.Data
{
    public class PlantBuddyContext : DbContext
    {
        public PlantBuddyContext (DbContextOptions<PlantBuddyContext> options)
            : base(options)
        {
        }

        public DbSet<Plant> Plants { get; set; } = default!;
        public DbSet<PlantPicture> PlantPictures { get; set; } = default!;
        public DbSet<Store> Stores { get; set; } = default!;
        public DbSet<WaterHistory> WaterHistories { get; set; } = default!;

    }
}
