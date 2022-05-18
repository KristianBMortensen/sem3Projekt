﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WashingAPI.DBModels
{
    public partial class Sem3Context : DbContext
    {
        public Sem3Context()
        {
        }

        public Sem3Context(DbContextOptions<Sem3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Day> Days { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<LoginRequest> LoginRequests { get; set; }
        public virtual DbSet<Timeslot> Timeslots { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=3sem.database.windows.net;Initial Catalog=sem3;Persist Security Info=True;User ID=fhs15;Password=cake123!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Day>(entity =>
            {
                entity.Property(e => e.ResDate).IsUnicode(false);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.GoogleId)
                    .HasName("PK__login__0DA2E483C4AD5186");

                entity.Property(e => e.GoogleId).IsUnicode(false);

                entity.Property(e => e.Efternavn).IsUnicode(false);

                entity.Property(e => e.Fornavn).IsUnicode(false);

                entity.Property(e => e.Rolle)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('user')");

                entity.Property(e => e.Room).IsUnicode(false);
            });

            modelBuilder.Entity<LoginRequest>(entity =>
            {
                entity.HasKey(e => e.GoogleId)
                    .HasName("PK__loginReq__0DA2E483C0BA4853");

                entity.Property(e => e.GoogleId).IsUnicode(false);

                entity.Property(e => e.Efternavn).IsUnicode(false);

                entity.Property(e => e.Fornavn).IsUnicode(false);

                entity.Property(e => e.Room).IsUnicode(false);
            });

            modelBuilder.Entity<Timeslot>(entity =>
            {
                entity.Property(e => e.ResTime).IsUnicode(false);

                entity.Property(e => e.RoomNo).IsUnicode(false);

                entity.HasOne(d => d.Day)
                    .WithMany(p => p.Timeslots)
                    .HasForeignKey(d => d.DayId)
                    .HasConstraintName("FK_With_cascade");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}