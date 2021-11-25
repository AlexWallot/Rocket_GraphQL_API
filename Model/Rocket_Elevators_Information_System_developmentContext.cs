using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DotNetGQL.Model
{
    public partial class Rocket_Elevators_Information_System_developmentContext : DbContext
    {
        public Rocket_Elevators_Information_System_developmentContext()
        {
        }

        public Rocket_Elevators_Information_System_developmentContext(DbContextOptions<Rocket_Elevators_Information_System_developmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<ArInternalMetadatum> ArInternalMetadata { get; set; }
        public virtual DbSet<Battery> Batteries { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<BuildingDetail> BuildingDetails { get; set; }
        public virtual DbSet<Column> Columns { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Elevator> Elevators { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Lead> Leads { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }
        public virtual DbSet<SchemaMigration> SchemaMigrations { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("name=ConnectionStrings:MySQLConnection", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.35-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("addresses");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("country");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Entity)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("entity");

                entity.Property(e => e.Lat).HasColumnName("lat");

                entity.Property(e => e.Long).HasColumnName("long");

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("notes");

                entity.Property(e => e.NumberAndStreet)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("numberAndStreet");

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("postalCode");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.SuiteOrApartment)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("suiteOrApartment");

                entity.Property(e => e.TypeAddress)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("typeAddress");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<ArInternalMetadatum>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("PRIMARY");

                entity.ToTable("ar_internal_metadata");

                entity.Property(e => e.Key).HasColumnName("key");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.Value)
                    .HasMaxLength(255)
                    .HasColumnName("value");
            });

            modelBuilder.Entity<Battery>(entity =>
            {
                entity.ToTable("batteries");

                entity.HasIndex(e => e.BuildingId, "fk_rails_a41b912b01");

                entity.HasIndex(e => e.EmployeeId, "fk_rails_b3952b46cb");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.BuildingId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("buildingId");

                entity.Property(e => e.CertificateOperations)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("certificateOperations");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.DateCommissioning)
                    .HasColumnType("datetime")
                    .HasColumnName("dateCommissioning");

                entity.Property(e => e.DateLastInspection)
                    .HasColumnType("datetime")
                    .HasColumnName("dateLastInspection");

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("employeeId");

                entity.Property(e => e.Information)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("information");

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("notes");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.Types)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("types");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Batteries)
                    .HasForeignKey(d => d.BuildingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rails_a41b912b01");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Batteries)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rails_b3952b46cb");
            });

            modelBuilder.Entity<Building>(entity =>
            {
                entity.ToTable("buildings");

                entity.HasIndex(e => e.AddressId, "fk_rails_1a4fe0cf30");

                entity.HasIndex(e => e.CustomerId, "fk_rails_e804dec3ca");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.AddressId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("addressId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("customerId");

                entity.Property(e => e.EmailAdministrator)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("emailAdministrator");

                entity.Property(e => e.EmailTechnicalContact)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("emailTechnicalContact");

                entity.Property(e => e.FullNameAdministrator)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("fullNameAdministrator");

                entity.Property(e => e.FullNameTechnicalContact)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("fullNameTechnicalContact");

                entity.Property(e => e.PhoneNumberAdministrator)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("phoneNumberAdministrator");

                entity.Property(e => e.PhoneTechnicalContact)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("phoneTechnicalContact");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rails_1a4fe0cf30");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rails_e804dec3ca");
            });

            modelBuilder.Entity<BuildingDetail>(entity =>
            {
                entity.ToTable("building_details");

                entity.HasIndex(e => e.BuildingId, "fk_rails_639c920861");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.BuildingId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("buildingId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.InformationKey)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("informationKey");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("value");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.BuildingDetails)
                    .HasForeignKey(d => d.BuildingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rails_639c920861");
            });

            modelBuilder.Entity<Column>(entity =>
            {
                entity.ToTable("columns");

                entity.HasIndex(e => e.BatteryId, "fk_rails_5c0968a3ea");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.BatteryId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("batteryId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Information)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("information");

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("notes");

                entity.Property(e => e.NumberFloorServed)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("numberFloorServed");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.Types)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("types");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Battery)
                    .WithMany(p => p.Columns)
                    .HasForeignKey(d => d.BatteryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rails_5c0968a3ea");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.HasIndex(e => e.AddressId, "fk_rails_71c8d57845");

                entity.HasIndex(e => e.UserId, "fk_rails_835ae73a22");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.AddressId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("addressId");

                entity.Property(e => e.CompagnyName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("compagnyName");

                entity.Property(e => e.ContactPhone)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("contactPhone");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.DateCreation)
                    .HasColumnType("datetime")
                    .HasColumnName("dateCreation");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("fullName");

                entity.Property(e => e.FullNameTechnicalAuthority)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("fullNameTechnicalAuthority");

                entity.Property(e => e.TechnicalAuthorityEmail)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("technicalAuthorityEmail");

                entity.Property(e => e.TechnicalAuthorityPhone)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("technicalAuthorityPhone");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("userId");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rails_71c8d57845");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rails_835ae73a22");
            });

            modelBuilder.Entity<Elevator>(entity =>
            {
                entity.ToTable("elevators");

                entity.HasIndex(e => e.ColumnId, "fk_rails_51711cce16");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.CertificateOperations)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("certificateOperations");

                entity.Property(e => e.ColumnId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("columnId");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.DateCommissioning)
                    .HasColumnType("datetime")
                    .HasColumnName("dateCommissioning");

                entity.Property(e => e.DateLastInspection)
                    .HasColumnType("datetime")
                    .HasColumnName("dateLastInspection");

                entity.Property(e => e.Information)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("information");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("model");

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("notes");

                entity.Property(e => e.SerialNumber)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("serialNumber");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.Types)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("types");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Column)
                    .WithMany(p => p.Elevators)
                    .HasForeignKey(d => d.ColumnId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rails_51711cce16");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");

                entity.HasIndex(e => e.UserId, "fk_rails_dcfd3d4fc3");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("last_name");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("title");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rails_dcfd3d4fc3");
            });

            modelBuilder.Entity<Lead>(entity =>
            {
                entity.ToTable("leads");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.CompagnyName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("compagnyName");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("department");

                entity.Property(e => e.DescriptionProject)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("descriptionProject");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.File)
                    .HasColumnType("blob")
                    .HasColumnName("file");

                entity.Property(e => e.FullNameContact)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("fullNameContact");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("message");

                entity.Property(e => e.NameProject)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nameProject");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Quote>(entity =>
            {
                entity.ToTable("quotes");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CompagnyName)
                    .HasMaxLength(255)
                    .HasColumnName("compagnyName");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.InstallationFees)
                    .HasPrecision(10)
                    .HasColumnName("installationFees");

                entity.Property(e => e.NumApartment)
                    .HasColumnType("int(11)")
                    .HasColumnName("numApartment");

                entity.Property(e => e.NumElevator)
                    .HasColumnType("int(11)")
                    .HasColumnName("numElevator");

                entity.Property(e => e.NumFloor)
                    .HasColumnType("int(11)")
                    .HasColumnName("numFloor");

                entity.Property(e => e.NumOccupant)
                    .HasColumnType("int(11)")
                    .HasColumnName("numOccupant");

                entity.Property(e => e.Total)
                    .HasPrecision(10)
                    .HasColumnName("total");

                entity.Property(e => e.TotalElevatorPrice)
                    .HasPrecision(10)
                    .HasColumnName("totalElevatorPrice");

                entity.Property(e => e.TypeBuilding)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("type_building");

                entity.Property(e => e.TypeService)
                    .HasMaxLength(255)
                    .HasColumnName("typeService");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<SchemaMigration>(entity =>
            {
                entity.HasKey(e => e.Version)
                    .HasName("PRIMARY");

                entity.ToTable("schema_migrations");

                entity.Property(e => e.Version).HasColumnName("version");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email, "index_users_on_email")
                    .IsUnique();

                entity.HasIndex(e => e.ResetPasswordToken, "index_users_on_reset_password_token")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email");

                entity.Property(e => e.EncryptedPassword)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("encrypted_password")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.RememberCreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("remember_created_at");

                entity.Property(e => e.ResetPasswordSentAt)
                    .HasColumnType("datetime")
                    .HasColumnName("reset_password_sent_at");

                entity.Property(e => e.ResetPasswordToken).HasColumnName("reset_password_token");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
