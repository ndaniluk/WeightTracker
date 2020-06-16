using Microsoft.EntityFrameworkCore;

namespace WeightTracker.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<LoginInfo> LoginInfo { get; set; }
        public DbSet<MeasurementRecord> MeasurementRecords { get; set; }
        public DbSet<BodyParameters> BodyParameters { get; set; }
        public DbSet<TrainingRecord> TrainingRecords { get; set; }
        public DbSet<TrainingNote> TrainingNotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}