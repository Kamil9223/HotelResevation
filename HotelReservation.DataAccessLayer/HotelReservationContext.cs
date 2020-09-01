using HotelReservation.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace HotelReservation.DataAccessLayer
{
    public partial class HotelReservationContext : DbContext
    {
        public HotelReservationContext()
        {
        }

        //public HotelReservationContext(DbContextOptions<HotelReservationContext> options)
        //    : base(options)
        //{
        //}

        public virtual DbSet<Guests> Guests { get; set; }
        public virtual DbSet<Reservations> Reservations { get; set; }
        public virtual DbSet<Rooms> Rooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-3PJT5O9;Initial Catalog=HotelReservation;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guests>(entity =>
            {
                entity.HasKey(e => e.GuestId)
                    .HasName("Guests_id_pk");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Guests__A9D105345574F983")
                    .IsUnique();

                entity.HasIndex(e => e.Phone)
                    .HasName("UQ__Guests__5C7E359E3734A6C4")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<Reservations>(entity =>
            {
                entity.HasKey(e => e.ReservationId)
                    .HasName("Reservations_id_pk");

                entity.Property(e => e.DateFrom).HasColumnType("date");

                entity.Property(e => e.DateTo).HasColumnType("date");

                entity.HasOne(d => d.Guest)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.GuestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Reservations_GiestId_fk");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.RoomNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Reservations_RoomNumber_fk");
            });

            modelBuilder.Entity<Rooms>(entity =>
            {
                entity.HasKey(e => e.RoomNumber)
                    .HasName("Rooms_id_pk");

                entity.Property(e => e.RoomNumber).ValueGeneratedNever();

                entity.Property(e => e.PricePerNight).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.RoomType).HasConversion(new EnumToNumberConverter<RoomType, byte>());
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
