using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WeightTracker.Entities;

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
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
