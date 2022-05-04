using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAL_Class.Models
{
    public partial class FlightApplicationDBContext : DbContext
    {
        public FlightApplicationDBContext()
        {
        }

        public FlightApplicationDBContext(DbContextOptions<FlightApplicationDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblFlightDetail> TblFlightDetails { get; set; }
        public virtual DbSet<TblUserDetail> TblUserDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=CTSDOTNET12;Database=FlightApplicationDB;User Id=sa;password=pass@word1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblFlightDetail>(entity =>
            {
                entity.HasKey(e => e.FlightId);

                entity.ToTable("tblFlightDetails");

                entity.Property(e => e.FlightId)
                    .ValueGeneratedNever()
                    .HasColumnName("FlightID");

                entity.Property(e => e.AirlineName)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.Bcseats).HasColumnName("BCSeats");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FromPlace)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Nbcseats).HasColumnName("NBCSeats");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.ToPlace)
                    .HasMaxLength(50)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TblUserDetail>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("tblUserDetails");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserID");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsFixedLength(true);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.PassWord)
                    .HasMaxLength(20)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
