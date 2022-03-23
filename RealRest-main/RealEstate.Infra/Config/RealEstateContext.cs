using RealEstate.Entities.Entities;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace RealEstate.Infra.Config
{
    public partial class RealEstateContext : DbContext
    {
        public IConfigurationRoot Configuration { get; set; }

        public RealEstateContext()
        {
        }

        public RealEstateContext(DbContextOptions<RealEstateContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<PropertyImage> PropertyImages { get; set; }
        public virtual DbSet<PropertyTrace> PropertyTraces { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetUrlConection());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>(entity =>
            {
                entity.HasKey(e => e.Idowner)
                    .HasName("pk_owner");

                entity.ToTable("Owner");

                entity.Property(e => e.Idowner).HasColumnName("idowner");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasColumnName("birthday");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Photo)
                    .IsUnicode(false)
                    .HasColumnName("photo");
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.HasKey(e => e.Idproperty)
                    .HasName("pk_property");

                entity.ToTable("Property");

                entity.Property(e => e.Idproperty).HasColumnName("idproperty");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Codeinternal).HasColumnName("codeinternal");

                entity.Property(e => e.Idowner).HasColumnName("idowner");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(20, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.IdownerNavigation)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.Idowner)
                    .HasConstraintName("FK_PropertyOwner");
            });

            modelBuilder.Entity<PropertyImage>(entity =>
            {
                entity.HasKey(e => e.Idpropertyimage)
                    .HasName("pk_property_image");

                entity.ToTable("PropertyImage");

                entity.Property(e => e.Idpropertyimage).HasColumnName("idpropertyimage");

                entity.Property(e => e.Enabled).HasColumnName("enabled");

                entity.Property(e => e.Filename)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("filename");

                entity.Property(e => e.Idproperty).HasColumnName("idproperty");

                entity.HasOne(d => d.IdpropertyNavigation)
                    .WithMany(p => p.PropertyImages)
                    .HasForeignKey(d => d.Idproperty)
                    .HasConstraintName("FK_PropertyPropertyImage");
            });

            modelBuilder.Entity<PropertyTrace>(entity =>
            {
                entity.HasKey(e => e.Idpropertytrace)
                    .HasName("pk_property_trace");

                entity.ToTable("PropertyTrace");

                entity.Property(e => e.Idpropertytrace).HasColumnName("idpropertytrace");

                entity.Property(e => e.Datesale)
                    .HasColumnType("date")
                    .HasColumnName("datesale");

                entity.Property(e => e.Idproperty).HasColumnName("idproperty");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Tax)
                    .HasColumnType("decimal(20, 2)")
                    .HasColumnName("tax");

                entity.Property(e => e.Value)
                    .HasColumnType("decimal(20, 2)")
                    .HasColumnName("value");

                entity.HasOne(d => d.IdpropertyNavigation)
                    .WithMany(p => p.PropertyTraces)
                    .HasForeignKey(d => d.Idproperty)
                    .HasConstraintName("FK_PropertyPropertyTrace");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public string GetUrlConection()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            string conexion = Configuration.GetConnectionString("DefaultConnection");
            return conexion;
        }
    }
}
