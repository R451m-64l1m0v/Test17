using Microsoft.EntityFrameworkCore;
using RegisterToDoctor.Domain.Constants;
using RegisterToDoctor.Domain.Entities;

namespace RegisterToDoctor.Infrastructure.DataAccessLayer.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Plot> Plots { get; set; }
        public DbSet<Specialization> Specializations { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
                .HasOne(p => p.Office)                
                .WithMany(b => b.Doctors);
            
            modelBuilder.Entity<Doctor>()
                .HasOne(p => p.Plot)
                .WithMany(b => b.Doctors);

            modelBuilder.Entity<Doctor>()
                .HasOne(p => p.Specialization)
                .WithMany(b => b.Doctors);

            modelBuilder.Entity<Patient>()
                .HasOne(p => p.Plot)
                .WithMany(b => b.Patients);

            modelBuilder.Entity<Patient>()                
                .HasOne(p => p.MedicalCard)
                .WithOne(b => b.Patient)
                .HasForeignKey<MedicalCard>(p => p.PatientId);

            modelBuilder.Entity<Patient>()
                .Property(e => e.DateOfBirth)
                .HasColumnType(ContextConstants.DateColumnType);

            modelBuilder.Entity<Patient>()
                .Property(x => x.OmsNumber)
                .HasMaxLength(16)
                .IsFixedLength();
        }

    }
}