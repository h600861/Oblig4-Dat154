using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAppOblig4.Models;

public partial class H600861Context : DbContext
{
    public H600861Context()
    {
    }

    public H600861Context(DbContextOptions<H600861Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseNpgsql("Host=ider-database.westeurope.cloudapp.azure.com;Database=h600861;Username=h600861;Password=abc123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("bookings_pkey");

            entity.ToTable("bookings", "hotel");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CheckinDate).HasColumnName("checkin_date");
            entity.Property(e => e.CheckoutDate).HasColumnName("checkout_date");
            entity.Property(e => e.CustomersEmail)
                .HasMaxLength(50)
                .HasColumnName("customers_email");
            entity.Property(e => e.RoomType)
                .HasMaxLength(50)
                .HasColumnName("room_type");

            entity.HasOne(d => d.CustomersEmailNavigation).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.CustomersEmail)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("email_fk");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("email_pk");

            entity.ToTable("customers", "hotel");

            entity.HasIndex(e => e.Email, "customers_email_key").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rooms_pkey");

            entity.ToTable("rooms", "hotel");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NumBeds).HasColumnName("num_beds");
            entity.Property(e => e.PricePerNight)
                .HasPrecision(10, 2)
                .HasColumnName("price_per_night");
         //   entity.Property(e => e.RoomNumber).HasColumnName("room_number");
         //   entity.Property(e => e.RoomSize).HasColumnName("room_size");
           entity.Property(e => e.roomType)
                .HasMaxLength(50)
                .HasColumnName("room_type");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tasks_pkey");

            entity.ToTable("tasks", "hotel");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.RoomNumber).HasColumnName("room_number");
            entity.Property(e => e.TaskNotes).HasColumnName("task_notes");
            entity.Property(e => e.TaskStatus)
                .HasMaxLength(20)
                .HasDefaultValueSql("'new'::character varying")
                .HasColumnName("task_status");
            entity.Property(e => e.TaskType)
                .HasMaxLength(50)
                .HasColumnName("task_type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
