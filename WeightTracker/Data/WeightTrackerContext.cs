using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WeightTracker.Entities;
using WeightTracker.Models;

namespace WeightTracker.Data
{
    public class WeightTrackerContext : IdentityDbContext<User>
    {
      public DbSet<User> UserInfo { get; set; }
      public DbSet<MeasurementRecord> MeasurementRecords { get; set; }
      public DbSet<TrainingRecord> TrainingRecords { get; set; }
      public WeightTrackerContext(DbContextOptions<WeightTrackerContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

         builder.Entity<TrainingRecord>().HasOne(e => e.User).WithMany()
            .OnDelete(DeleteBehavior.Cascade);
         builder.Entity<MeasurementRecord>().HasOne(e => e.User).WithMany()
            .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<WeightTracker.Models.AdminPanelUser> AdminPanelUser { get; set; }
    }
}
