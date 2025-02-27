using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Parking_Management.Domain.Entities;

namespace Parking_Management.Domain.Entities;

public partial class ParkingManagementContext : DbContext
{
    public ParkingManagementContext(DbContextOptions<ParkingManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Camera> Cameras { get; set; }

    public virtual DbSet<Card> Cards { get; set; }

    public virtual DbSet<CardGroup> CardGroups { get; set; }

    public virtual DbSet<Computer> Computers { get; set; }

    public virtual DbSet<ControlUnit> ControlUnits { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<EntryLog> EntryLogs { get; set; }

    public virtual DbSet<ExitLog> ExitLogs { get; set; }

    public virtual DbSet<Gate> Gates { get; set; }

    public virtual DbSet<Lane> Lanes { get; set; }

    public virtual DbSet<LaneCamera> LaneCameras { get; set; }

    public virtual DbSet<LaneController> LaneControllers { get; set; }

    public virtual DbSet<Led> Leds { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Camera>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cameras__3213E83FDB0CEB70");

            entity.ToTable("cameras");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ComputerId).HasColumnName("computer_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ip_address");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Resolution)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("resolution");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.Computer).WithMany(p => p.Cameras)
                .HasForeignKey(d => d.ComputerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__cameras__compute__22751F6C");
        });

        modelBuilder.Entity<Card>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cards__3213E83F97C1DB8C");

            entity.ToTable("cards");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Customer).WithMany(p => p.Cards)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__cards__customer___440B1D61");

            entity.HasOne(d => d.Group).WithMany(p => p.Cards)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__cards__group_id__4316F928");
        });

        modelBuilder.Entity<CardGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__card_gro__3213E83F8CE93CEA");

            entity.ToTable("card_groups");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Computer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__computer__3213E83FF0007F28");

            entity.ToTable("computers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.GateId).HasColumnName("gate_id");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ip_address");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Gate).WithMany(p => p.Computers)
                .HasForeignKey(d => d.GateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__computers__gate___1CBC4616");
        });

        modelBuilder.Entity<ControlUnit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__control___3213E83FEAB6B0EA");

            entity.ToTable("control_units");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ComputerId).HasColumnName("computer_id");
            entity.Property(e => e.ConnectionProtocol)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("connection_protocol");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.Computer).WithMany(p => p.ControlUnits)
                .HasForeignKey(d => d.ComputerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__control_u__compu__29221CFB");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__customer__3213E83F08AFB119");

            entity.ToTable("customers");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Room)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("room");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<EntryLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__entry_lo__3213E83F247A0FB8");

            entity.ToTable("entry_logs");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CardId).HasColumnName("card_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.EntryLane)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("entry_lane");
            entity.Property(e => e.EntryTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("entry_time");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("image_url");
            entity.Property(e => e.PlateNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("plate_number");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.VehicleType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("vehicle_type");

            entity.HasOne(d => d.Card).WithMany(p => p.EntryLogs)
                .HasForeignKey(d => d.CardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__entry_log__card___4AB81AF0");
        });

        modelBuilder.Entity<ExitLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__exit_log__3213E83F0ED6471A");

            entity.ToTable("exit_logs");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CardId).HasColumnName("card_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.EntryId).HasColumnName("entry_id");
            entity.Property(e => e.ExitLane)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("exit_lane");
            entity.Property(e => e.ExitTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("exit_time");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("image_url");
            entity.Property(e => e.PlateNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("plate_number");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.VehicleType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("vehicle_type");

            entity.HasOne(d => d.Card).WithMany(p => p.ExitLogs)
                .HasForeignKey(d => d.CardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__exit_logs__card___5165187F");

            entity.HasOne(d => d.Entry).WithMany(p => p.ExitLogs)
                .HasForeignKey(d => d.EntryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__exit_logs__entry__52593CB8");
        });

        modelBuilder.Entity<Gate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__gates__3213E83FE0E99CC4");

            entity.ToTable("gates");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Lane>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__lanes__3213E83F889E2FAE");

            entity.ToTable("lanes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ComputerId).HasColumnName("computer_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Computer).WithMany(p => p.Lanes)
                .HasForeignKey(d => d.ComputerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__lanes__computer___2EDAF651");
        });

        modelBuilder.Entity<LaneCamera>(entity =>
        {
            entity.HasKey(e => new { e.LaneId, e.CameraId }).HasName("PK__lane_cam__ADA88835DE54533A");

            entity.ToTable("lane_cameras");

            entity.Property(e => e.LaneId).HasColumnName("lane_id");
            entity.Property(e => e.CameraId).HasColumnName("camera_id");
            entity.Property(e => e.CameraType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("camera_type");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Purpose)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("purpose");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Camera).WithMany(p => p.LaneCameras)
                .HasForeignKey(d => d.CameraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__lane_came__camer__3C34F16F");

            entity.HasOne(d => d.Lane).WithMany(p => p.LaneCameras)
                .HasForeignKey(d => d.LaneId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__lane_came__lane___3B40CD36");
        });

        modelBuilder.Entity<LaneController>(entity =>
        {
            entity.HasKey(e => new { e.LaneId, e.ControlUnitId }).HasName("PK__lane_con__A795E88A54769313");

            entity.ToTable("lane_controllers");

            entity.Property(e => e.LaneId).HasColumnName("lane_id");
            entity.Property(e => e.ControlUnitId).HasColumnName("control_unit_id");
            entity.Property(e => e.Alarm)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("alarm");
            entity.Property(e => e.Barrier)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("barrier");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Input)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("input");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.ControlUnit).WithMany(p => p.LaneControllers)
                .HasForeignKey(d => d.ControlUnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__lane_cont__contr__44CA3770");

            entity.HasOne(d => d.Lane).WithMany(p => p.LaneControllers)
                .HasForeignKey(d => d.LaneId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__lane_cont__lane___43D61337");
        });

        modelBuilder.Entity<Led>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__led__3213E83F96F277AA");

            entity.ToTable("led");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ComputerId).HasColumnName("computer_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Computer).WithMany(p => p.Leds)
                .HasForeignKey(d => d.ComputerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__led__computer_id__3493CFA7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
