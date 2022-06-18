using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Core
{
    public partial class UtilityBillsContext : DbContext
    {
        public UtilityBillsContext()
        {
        }

        public UtilityBillsContext(DbContextOptions<UtilityBillsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CalcMeter> CalcMeter { get; set; }
        public virtual DbSet<KindMeter> KindMeter { get; set; }
        public virtual DbSet<Measurement> Measurement { get; set; }
        public virtual DbSet<Meter> Meter { get; set; }
        public virtual DbSet<Pay> Pay { get; set; }
        public virtual DbSet<Price> Price { get; set; }
        public virtual DbSet<TypeMeter> TypeMeter { get; set; }
        public virtual DbSet<TypePay> TypePay { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=UtilityBills;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CalcMeter>(entity =>
            {
                entity.HasOne(d => d.Measurement)
                    .WithMany(p => p.CalcMeter)
                    .HasForeignKey(d => d.MeasurementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CalcMeter_Measurement");

                entity.HasOne(d => d.TypePay)
                    .WithMany(p => p.CalcMeter)
                    .HasForeignKey(d => d.TypePayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CalcMeter_TypePay");
            });

            modelBuilder.Entity<KindMeter>(entity =>
            {
                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<Measurement>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Meter)
                    .WithMany(p => p.Measurement)
                    .HasForeignKey(d => d.MeterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Measurement_Meter");
            });

            modelBuilder.Entity<Meter>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.TypeMeter)
                    .WithMany(p => p.Meter)
                    .HasForeignKey(d => d.TypeMeterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Meter_TypeMeter");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Meter)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Meter_User");
            });

            modelBuilder.Entity<Pay>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Sum).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Pay)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Pay");
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.TypePay)
                    .WithMany(p => p.Price)
                    .HasForeignKey(d => d.TypePayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Price_TypePay");
            });

            modelBuilder.Entity<TypeMeter>(entity =>
            {
                entity.Property(e => e.Title)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.KindMeter)
                    .WithMany(p => p.TypeMeter)
                    .HasForeignKey(d => d.KindMeterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TypeMeter_KindMeter");
            });

            modelBuilder.Entity<TypePay>(entity =>
            {
                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.Login).IsRequired();

                entity.Property(e => e.Pasword).IsRequired();

                entity.Property(e => e.SecondName).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
