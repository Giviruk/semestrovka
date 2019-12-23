﻿using Microsoft.EntityFrameworkCore;
using Semestrovka.Models.DBModels;

namespace Semestrovka.Data
{
    public partial class d6h4jeg5tcb9d8Context : DbContext
    {
        public d6h4jeg5tcb9d8Context()
        {
        }

        public d6h4jeg5tcb9d8Context(DbContextOptions<d6h4jeg5tcb9d8Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Deliveries> Deliveries { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Ordersofusers> Ordersofusers { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Productimages> Productimages { get; set; }
        public virtual DbSet<Productinorder> Productinorder { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<Statuses> Statuses { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=ec2-54-75-224-168.eu-west-1.compute.amazonaws.com;Port=5432;Database=d6h4jeg5tcb9d8;Username= wkbpbpaxngudla;Password=59246a01b58aadced8f913a1350af1ca65465b378b26b9f6ed388845695b3bdf;sslmode=Require;Trust Server Certificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Characteristics)
                    .HasColumnName("characteristics")
                    .HasMaxLength(1000);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Cities>(entity =>
            {
                entity.ToTable("cities");

                entity.HasIndex(e => e.Name)
                    .HasName("unique_city")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Deliveries>(entity =>
            {
                entity.ToTable("deliveries");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Addressdelivery)
                    .HasColumnName("addressdelivery")
                    .HasMaxLength(255);

                entity.Property(e => e.Datedelivery)
                    .HasColumnName("datedelivery")
                    .HasColumnType("date");

                entity.Property(e => e.Pointofissue)
                    .HasColumnName("pointofissue")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Images>(entity =>
            {
                entity.ToTable("images");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Imagename)
                    .HasColumnName("imagename")
                    .HasMaxLength(255);

                entity.Property(e => e.Imagepath)
                    .HasColumnName("imagepath")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(255);

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.Delivery).HasColumnName("delivery");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.Owner).HasColumnName("owner");

                entity.Property(e => e.PayType)
                    .HasColumnName("payType")
                    .HasMaxLength(255);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phoneNumber")
                    .HasMaxLength(255);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.DeliveryNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Delivery)
                    .HasConstraintName("orders_delivery_fkey");

                entity.HasOne(d => d.OwnerNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Owner)
                    .HasConstraintName("orders_owner_fkey");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("orders_status_fkey");
            });

            modelBuilder.Entity<Ordersofusers>(entity =>
            {
                entity.ToTable("ordersofusers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Ordersofusers)
                    .HasForeignKey(d => d.Orderid)
                    .HasConstraintName("ordersofusers_orderid_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ordersofusers)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("ordersofusers_userid_fkey");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.Characteristics)
                    .HasColumnName("characteristics")
                    .HasMaxLength(1000);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(1000);

                entity.Property(e => e.Mainpictureurl).HasColumnName("mainpictureurl");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Producer)
                    .HasColumnName("producer")
                    .HasMaxLength(255);

                entity.Property(e => e.ProductRating).HasColumnName("product_rating");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.Category)
                    .HasConstraintName("product_category_fkey");

                entity.HasOne(d => d.MainpictureurlNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.Mainpictureurl)
                    .HasConstraintName("product_mainpictureurl_fkey");
            });

            modelBuilder.Entity<Productimages>(entity =>
            {
                entity.ToTable("productimages");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Imageid).HasColumnName("imageid");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Productimages)
                    .HasForeignKey(d => d.Imageid)
                    .HasConstraintName("productimages_imageid_fkey");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Productimages)
                    .HasForeignKey(d => d.Productid)
                    .HasConstraintName("productimages_productid_fkey");
            });

            modelBuilder.Entity<Productinorder>(entity =>
            {
                entity.ToTable("productinorder");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Productinorder)
                    .HasForeignKey(d => d.Orderid)
                    .HasConstraintName("productinorder_orderid_fkey");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Productinorder)
                    .HasForeignKey(d => d.Productid)
                    .HasConstraintName("productinorder_productid_fkey");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("review");

                entity.Property(e => e.ReviewId).HasColumnName("review_id");

                entity.Property(e => e.AuthorId)
                    .HasColumnName("author_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ProductAdvantages).HasColumnName("product_advantages");

                entity.Property(e => e.ProductDisadvantages).HasColumnName("product_disadvantages");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ProductRating).HasColumnName("product_rating");

                entity.Property(e => e.ReviewComment).HasColumnName("review_comment");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_id_fk");
            });

            modelBuilder.Entity<Statuses>(entity =>
            {
                entity.ToTable("statuses");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Login)
                    .HasName("unique_login")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address).HasMaxLength(400);

                entity.Property(e => e.City).HasColumnName("city");

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(255);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(255);

                entity.Property(e => e.Login).HasMaxLength(255);

                entity.Property(e => e.Middlename)
                    .HasColumnName("middlename")
                    .HasMaxLength(255);

                entity.Property(e => e.Pass).HasMaxLength(255);

                entity.Property(e => e.Token).HasMaxLength(255);

                entity.HasOne(d => d.CityNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.City)
                    .HasConstraintName("users_city_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
