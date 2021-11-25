using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DotNetGQL.Model
{
    public partial class Alex_WallotContext : DbContext
    {
        public Alex_WallotContext()
        {
        }

        public Alex_WallotContext(DbContextOptions<Alex_WallotContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ArInternalMetadatum> ArInternalMetadata { get; set; }
        public virtual DbSet<DimCustomer> DimCustomers { get; set; }
        public virtual DbSet<FactContact> FactContacts { get; set; }
        public virtual DbSet<FactElevator> FactElevators { get; set; }
        public virtual DbSet<FactIntervention> FactInterventions { get; set; }
        public virtual DbSet<FactQuote> FactQuotes { get; set; }
        public virtual DbSet<SchemaMigration> SchemaMigrations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Name=ConnectionStrings:PostgreSQLConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.UTF-8");

            modelBuilder.Entity<ArInternalMetadatum>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("ar_internal_metadata_pkey");

                entity.ToTable("ar_internal_metadata");

                entity.Property(e => e.Key)
                    .HasColumnType("character varying")
                    .HasColumnName("key");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.Value)
                    .HasColumnType("character varying")
                    .HasColumnName("value");
            });

            modelBuilder.Entity<DimCustomer>(entity =>
            {
                entity.ToTable("dim_customers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("city");

                entity.Property(e => e.CompagnyName)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("compagnyName");

                entity.Property(e => e.CreationDate).HasColumnName("creation_date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("email");

                entity.Property(e => e.FullNameContact)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("fullNameContact");

                entity.Property(e => e.NbElevator).HasColumnName("nbElevator");
            });

            modelBuilder.Entity<FactContact>(entity =>
            {
                entity.ToTable("fact_contacts");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompagnyName)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("compagnyName");

                entity.Property(e => e.ContactId).HasColumnName("contactId");

                entity.Property(e => e.CreationDate).HasColumnName("creation_date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("email");

                entity.Property(e => e.NameProject)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("nameProject");
            });

            modelBuilder.Entity<FactElevator>(entity =>
            {
                entity.ToTable("fact_elevators");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BuildingId).HasColumnName("buildingId");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("city");

                entity.Property(e => e.CustomerId).HasColumnName("customerId");

                entity.Property(e => e.DateCommissioning).HasColumnName("dateCommissioning");

                entity.Property(e => e.SerialNumber)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("serialNumber");
            });

            modelBuilder.Entity<FactIntervention>(entity =>
            {
                entity.ToTable("fact_interventions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BatteryId).HasColumnName("batteryID");

                entity.Property(e => e.BuildingId).HasColumnName("buildingID");

                entity.Property(e => e.ColumnId).HasColumnName("columnID");

                entity.Property(e => e.DateAndTimeInterventionEnd).HasColumnName("dateAndTimeInterventionEnd");

                entity.Property(e => e.DateAndTimeInterventionStart).HasColumnName("dateAndTimeInterventionStart");

                entity.Property(e => e.ElevatorId).HasColumnName("elevatorID");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeID");

                entity.Property(e => e.Report)
                    .HasColumnType("character varying")
                    .HasColumnName("report");

                entity.Property(e => e.Result)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("result");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("status");
            });

            modelBuilder.Entity<FactQuote>(entity =>
            {
                entity.ToTable("fact_quotes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompagnyName)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("compagnyName");

                entity.Property(e => e.CreationDate).HasColumnName("creation_date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("email");

                entity.Property(e => e.NbElevator).HasColumnName("nbElevator");

                entity.Property(e => e.QuoteId).HasColumnName("quoteId");
            });

            modelBuilder.Entity<SchemaMigration>(entity =>
            {
                entity.HasKey(e => e.Version)
                    .HasName("schema_migrations_pkey");

                entity.ToTable("schema_migrations");

                entity.Property(e => e.Version)
                    .HasColumnType("character varying")
                    .HasColumnName("version");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
