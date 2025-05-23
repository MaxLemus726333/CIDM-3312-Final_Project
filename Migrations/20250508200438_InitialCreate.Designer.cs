﻿// <auto-generated />
using CIDM_3312_Final_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CIDM_3312_Final_Project.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250508200438_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.4");

            modelBuilder.Entity("CIDM_3312_Final_Project.Models.Card", b =>
                {
                    b.Property<int>("CardID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CardID");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("CIDM_3312_Final_Project.Models.Collection", b =>
                {
                    b.Property<int>("CollectionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CollectionID");

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("CIDM_3312_Final_Project.Models.CollectionCard", b =>
                {
                    b.Property<int>("CardID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CollectionID")
                        .HasColumnType("INTEGER");

                    b.HasKey("CardID", "CollectionID");

                    b.HasIndex("CollectionID");

                    b.ToTable("CollectionCards");
                });

            modelBuilder.Entity("CIDM_3312_Final_Project.Models.CollectionCard", b =>
                {
                    b.HasOne("CIDM_3312_Final_Project.Models.Card", "Card")
                        .WithMany("CollectionCards")
                        .HasForeignKey("CardID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CIDM_3312_Final_Project.Models.Collection", "Collection")
                        .WithMany()
                        .HasForeignKey("CollectionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Card");

                    b.Navigation("Collection");
                });

            modelBuilder.Entity("CIDM_3312_Final_Project.Models.Card", b =>
                {
                    b.Navigation("CollectionCards");
                });
#pragma warning restore 612, 618
        }
    }
}
