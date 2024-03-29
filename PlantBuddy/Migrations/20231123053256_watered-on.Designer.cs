﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlantBuddy.Data;

#nullable disable

namespace PlantBuddy.Migrations
{
    [DbContext(typeof(PlantBuddyContext))]
    [Migration("20231123053256_watered-on")]
    partial class wateredon
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PlantBuddy.Models.Plant", b =>
                {
                    b.Property<int>("PlantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlantId"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LightPreference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlantName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResourceLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StoreId")
                        .HasColumnType("int");

                    b.HasKey("PlantId");

                    b.HasIndex("StoreId");

                    b.ToTable("Plants");
                });

            modelBuilder.Entity("PlantBuddy.Models.PlantPicture", b =>
                {
                    b.Property<int>("PlantPictureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlantPictureId"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Picture")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PictureName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlantId")
                        .HasColumnType("int");

                    b.HasKey("PlantPictureId");

                    b.HasIndex("PlantId");

                    b.ToTable("PlantPictures");
                });

            modelBuilder.Entity("PlantBuddy.Models.Store", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StoreId"), 1L, 1);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StoreAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StoreId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("PlantBuddy.Models.WaterHistory", b =>
                {
                    b.Property<int>("WaterHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WaterHistoryId"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PlantId")
                        .HasColumnType("int");

                    b.Property<DateTime>("WateredOn")
                        .HasColumnType("datetime2");

                    b.HasKey("WaterHistoryId");

                    b.HasIndex("PlantId");

                    b.ToTable("WaterHistories");
                });

            modelBuilder.Entity("PlantBuddy.Models.Plant", b =>
                {
                    b.HasOne("PlantBuddy.Models.Store", "Store")
                        .WithMany("PlantsBoughtFromStore")
                        .HasForeignKey("StoreId");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("PlantBuddy.Models.PlantPicture", b =>
                {
                    b.HasOne("PlantBuddy.Models.Plant", "Plant")
                        .WithMany("Pictures")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("PlantBuddy.Models.WaterHistory", b =>
                {
                    b.HasOne("PlantBuddy.Models.Plant", "Plant")
                        .WithMany("WaterHistories")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("PlantBuddy.Models.Plant", b =>
                {
                    b.Navigation("Pictures");

                    b.Navigation("WaterHistories");
                });

            modelBuilder.Entity("PlantBuddy.Models.Store", b =>
                {
                    b.Navigation("PlantsBoughtFromStore");
                });
#pragma warning restore 612, 618
        }
    }
}
