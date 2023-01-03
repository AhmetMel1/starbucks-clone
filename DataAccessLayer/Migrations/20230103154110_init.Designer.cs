﻿// <auto-generated />
using System;
using DataAccessLayer.ConCreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230103154110_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EntityLayer.Address", b =>
                {
                    b.Property<int>("addressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("addressId"));

                    b.Property<bool>("addressDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("apartmentNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("district")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("neighbourhood")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("province")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("street")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("addressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("EntityLayer.CargoProcess", b =>
                {
                    b.Property<int>("cargoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cargoId"));

                    b.Property<bool>("cargoProcessDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("cargoStatus")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("cargoId");

                    b.ToTable("CargoProcesses");
                });

            modelBuilder.Entity("EntityLayer.Category", b =>
                {
                    b.Property<int>("categoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("categoryId"));

                    b.Property<bool>("categoryDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("categoryLogoUrl")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("categoryParentId")
                        .HasColumnType("int");

                    b.HasKey("categoryId");

                    b.HasIndex("categoryParentId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EntityLayer.Customization", b =>
                {
                    b.Property<int>("customizationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("customizationId"));

                    b.Property<bool>("customizationDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("customizationName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("optionId")
                        .HasColumnType("int");

                    b.HasKey("customizationId");

                    b.HasIndex("optionId");

                    b.ToTable("Customizations");
                });

            modelBuilder.Entity("EntityLayer.Favorite", b =>
                {
                    b.Property<int>("favoriteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("favoriteId"));

                    b.Property<bool>("favoriteDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.Property<DateTime>("uploadDate")
                        .HasMaxLength(50)
                        .HasColumnType("datetime2");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("favoriteId");

                    b.HasIndex("productId");

                    b.HasIndex("userId");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("EntityLayer.Menu", b =>
                {
                    b.Property<int>("menuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("menuId"));

                    b.Property<bool>("menuDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("menuName")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<int?>("menuParentId")
                        .HasColumnType("int");

                    b.HasKey("menuId");

                    b.HasIndex("menuParentId");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("EntityLayer.Option", b =>
                {
                    b.Property<int>("optionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("optionId"));

                    b.Property<bool>("optionDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("optionName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("optionParentId")
                        .HasColumnType("int");

                    b.Property<int>("optionTypeId")
                        .HasColumnType("int");

                    b.Property<int>("optionUnitPrice")
                        .HasColumnType("int");

                    b.HasKey("optionId");

                    b.HasIndex("optionParentId");

                    b.HasIndex("optionTypeId");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("EntityLayer.OptionType", b =>
                {
                    b.Property<int>("optionTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("optionTypeId"));

                    b.Property<bool>("optionTypeDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("optionTypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("optionTypeId");

                    b.ToTable("OptionTypes");
                });

            modelBuilder.Entity("EntityLayer.Order", b =>
                {
                    b.Property<int>("orderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("orderId"));

                    b.Property<DateTime>("cardAddedDate")
                        .HasMaxLength(50)
                        .HasColumnType("datetime2");

                    b.Property<int>("cargoId")
                        .HasColumnType("int");

                    b.Property<int>("cargoProcesscargoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("orderDate")
                        .HasMaxLength(50)
                        .HasColumnType("datetime2");

                    b.Property<bool>("orderDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("orderQuantity")
                        .HasColumnType("int");

                    b.Property<byte>("orderStatus")
                        .HasColumnType("tinyint");

                    b.Property<byte>("paymentType")
                        .HasColumnType("tinyint");

                    b.Property<int>("productSizeId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("orderId");

                    b.HasIndex("cargoProcesscargoId");

                    b.HasIndex("productSizeId");

                    b.HasIndex("userId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EntityLayer.Product", b =>
                {
                    b.Property<int>("productId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("productId"));

                    b.Property<int>("categoryId")
                        .HasColumnType("int");

                    b.Property<bool>("productDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("productDescription")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("productLogoUrl")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("productId");

                    b.HasIndex("categoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EntityLayer.ProductCustomization", b =>
                {
                    b.Property<int>("productCustomizationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("productCustomizationId"));

                    b.Property<int>("customizationId")
                        .HasColumnType("int");

                    b.Property<bool>("productCustomizationDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.HasKey("productCustomizationId");

                    b.HasIndex("customizationId");

                    b.HasIndex("productId");

                    b.ToTable("ProductCustomizations");
                });

            modelBuilder.Entity("EntityLayer.ProductSize", b =>
                {
                    b.Property<int>("productSizeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("productSizeId"));

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.Property<int>("productSizeCapacity")
                        .HasColumnType("int");

                    b.Property<bool>("productSizeDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("productSizePrice")
                        .HasColumnType("int");

                    b.Property<int>("sizeId")
                        .HasColumnType("int");

                    b.Property<int>("unitPrice")
                        .HasColumnType("int");

                    b.HasKey("productSizeId");

                    b.HasIndex("productId");

                    b.HasIndex("sizeId");

                    b.ToTable("ProductSizes");
                });

            modelBuilder.Entity("EntityLayer.Property", b =>
                {
                    b.Property<int>("PropertyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PropertyId"));

                    b.Property<bool>("PropertyDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PropertyMode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PropertyId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("EntityLayer.Size", b =>
                {
                    b.Property<int>("sizeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("sizeId"));

                    b.Property<bool>("sizeDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("sizeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("sizeId");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("EntityLayer.Store", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StoreId"));

                    b.Property<bool>("StoreDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("StoreLocation")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StoreId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("EntityLayer.StoreFavorite", b =>
                {
                    b.Property<int>("StoreFavoriteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StoreFavoriteId"));

                    b.Property<bool>("StoreFavoriteDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.HasKey("StoreFavoriteId");

                    b.HasIndex("StoreId");

                    b.ToTable("StoreFavorites");
                });

            modelBuilder.Entity("EntityLayer.StoreOpeningHour", b =>
                {
                    b.Property<int>("storeOpeningHourId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("storeOpeningHourId"));

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.Property<bool>("StoreOpeningHourDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("workTimeId")
                        .HasColumnType("int");

                    b.HasKey("storeOpeningHourId");

                    b.HasIndex("StoreId");

                    b.HasIndex("workTimeId");

                    b.ToTable("StoreOpeningHours");
                });

            modelBuilder.Entity("EntityLayer.StoreProduct", b =>
                {
                    b.Property<int>("StoreProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StoreProductId"));

                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("int");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.Property<bool>("StoreProductDeleted")
                        .HasColumnType("bit");

                    b.HasKey("StoreProductId");

                    b.HasIndex("PropertyId");

                    b.HasIndex("StoreId");

                    b.ToTable("StoreProducts");
                });

            modelBuilder.Entity("EntityLayer.StoreProperty", b =>
                {
                    b.Property<int>("StorePropertyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StorePropertyId"));

                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.Property<bool>("StorePropertyDeleted")
                        .HasColumnType("bit");

                    b.HasKey("StorePropertyId");

                    b.HasIndex("PropertyId");

                    b.HasIndex("StoreId");

                    b.ToTable("StoreProperties");
                });

            modelBuilder.Entity("EntityLayer.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userId"));

                    b.Property<int>("addressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("userDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("userTypeId")
                        .HasColumnType("int");

                    b.HasKey("userId");

                    b.HasIndex("addressId");

                    b.HasIndex("userTypeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EntityLayer.UserType", b =>
                {
                    b.Property<int>("userTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userTypeId"));

                    b.Property<bool>("userTypeDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("userTypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("userTypeId");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("EntityLayer.WorkTime", b =>
                {
                    b.Property<int>("workTimeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("workTimeId"));

                    b.Property<bool>("WorkTimeDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("closingTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("openingTime")
                        .HasColumnType("datetime2");

                    b.HasKey("workTimeId");

                    b.ToTable("WorkTimes");
                });

            modelBuilder.Entity("EntityLayer.Category", b =>
                {
                    b.HasOne("EntityLayer.Category", "categoryParent")
                        .WithMany("categoryChildren")
                        .HasForeignKey("categoryParentId");

                    b.Navigation("categoryParent");
                });

            modelBuilder.Entity("EntityLayer.Customization", b =>
                {
                    b.HasOne("EntityLayer.Option", "option")
                        .WithMany("customizations")
                        .HasForeignKey("optionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("option");
                });

            modelBuilder.Entity("EntityLayer.Favorite", b =>
                {
                    b.HasOne("EntityLayer.Product", "product")
                        .WithMany("favorites")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.User", "user")
                        .WithMany("favorites")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");

                    b.Navigation("user");
                });

            modelBuilder.Entity("EntityLayer.Menu", b =>
                {
                    b.HasOne("EntityLayer.Menu", "menuParent")
                        .WithMany("menuChildren")
                        .HasForeignKey("menuParentId");

                    b.Navigation("menuParent");
                });

            modelBuilder.Entity("EntityLayer.Option", b =>
                {
                    b.HasOne("EntityLayer.Option", "optionParent")
                        .WithMany("optionChildren")
                        .HasForeignKey("optionParentId");

                    b.HasOne("EntityLayer.OptionType", "optionType")
                        .WithMany("options")
                        .HasForeignKey("optionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("optionParent");

                    b.Navigation("optionType");
                });

            modelBuilder.Entity("EntityLayer.Order", b =>
                {
                    b.HasOne("EntityLayer.CargoProcess", "cargoProcess")
                        .WithMany("orders")
                        .HasForeignKey("cargoProcesscargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.ProductSize", "productSize")
                        .WithMany("orders")
                        .HasForeignKey("productSizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.User", "user")
                        .WithMany("orders")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cargoProcess");

                    b.Navigation("productSize");

                    b.Navigation("user");
                });

            modelBuilder.Entity("EntityLayer.Product", b =>
                {
                    b.HasOne("EntityLayer.Category", "category")
                        .WithMany("products")
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
                });

            modelBuilder.Entity("EntityLayer.ProductCustomization", b =>
                {
                    b.HasOne("EntityLayer.Customization", "customization")
                        .WithMany("productCustomizations")
                        .HasForeignKey("customizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Product", "product")
                        .WithMany("productCustomizations")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("customization");

                    b.Navigation("product");
                });

            modelBuilder.Entity("EntityLayer.ProductSize", b =>
                {
                    b.HasOne("EntityLayer.Product", "product")
                        .WithMany("productSizes")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Size", "size")
                        .WithMany("productSizes")
                        .HasForeignKey("sizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");

                    b.Navigation("size");
                });

            modelBuilder.Entity("EntityLayer.StoreFavorite", b =>
                {
                    b.HasOne("EntityLayer.Store", "Store")
                        .WithMany("StoreFavorites")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("EntityLayer.StoreOpeningHour", b =>
                {
                    b.HasOne("EntityLayer.Store", "Store")
                        .WithMany("StoreOpeningHours")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.WorkTime", "workTime")
                        .WithMany("StoreOpenings")
                        .HasForeignKey("workTimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");

                    b.Navigation("workTime");
                });

            modelBuilder.Entity("EntityLayer.StoreProduct", b =>
                {
                    b.HasOne("EntityLayer.Property", "Property")
                        .WithMany()
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Store", "Store")
                        .WithMany("StoreProducts")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("EntityLayer.StoreProperty", b =>
                {
                    b.HasOne("EntityLayer.Property", "Property")
                        .WithMany("StoreProperties")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Store", "Store")
                        .WithMany("StoreProperties")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("EntityLayer.User", b =>
                {
                    b.HasOne("EntityLayer.Address", "address")
                        .WithMany("users")
                        .HasForeignKey("addressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.UserType", "userType")
                        .WithMany("users")
                        .HasForeignKey("userTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("address");

                    b.Navigation("userType");
                });

            modelBuilder.Entity("EntityLayer.Address", b =>
                {
                    b.Navigation("users");
                });

            modelBuilder.Entity("EntityLayer.CargoProcess", b =>
                {
                    b.Navigation("orders");
                });

            modelBuilder.Entity("EntityLayer.Category", b =>
                {
                    b.Navigation("categoryChildren");

                    b.Navigation("products");
                });

            modelBuilder.Entity("EntityLayer.Customization", b =>
                {
                    b.Navigation("productCustomizations");
                });

            modelBuilder.Entity("EntityLayer.Menu", b =>
                {
                    b.Navigation("menuChildren");
                });

            modelBuilder.Entity("EntityLayer.Option", b =>
                {
                    b.Navigation("customizations");

                    b.Navigation("optionChildren");
                });

            modelBuilder.Entity("EntityLayer.OptionType", b =>
                {
                    b.Navigation("options");
                });

            modelBuilder.Entity("EntityLayer.Product", b =>
                {
                    b.Navigation("favorites");

                    b.Navigation("productCustomizations");

                    b.Navigation("productSizes");
                });

            modelBuilder.Entity("EntityLayer.ProductSize", b =>
                {
                    b.Navigation("orders");
                });

            modelBuilder.Entity("EntityLayer.Property", b =>
                {
                    b.Navigation("StoreProperties");
                });

            modelBuilder.Entity("EntityLayer.Size", b =>
                {
                    b.Navigation("productSizes");
                });

            modelBuilder.Entity("EntityLayer.Store", b =>
                {
                    b.Navigation("StoreFavorites");

                    b.Navigation("StoreOpeningHours");

                    b.Navigation("StoreProducts");

                    b.Navigation("StoreProperties");
                });

            modelBuilder.Entity("EntityLayer.User", b =>
                {
                    b.Navigation("favorites");

                    b.Navigation("orders");
                });

            modelBuilder.Entity("EntityLayer.UserType", b =>
                {
                    b.Navigation("users");
                });

            modelBuilder.Entity("EntityLayer.WorkTime", b =>
                {
                    b.Navigation("StoreOpenings");
                });
#pragma warning restore 612, 618
        }
    }
}