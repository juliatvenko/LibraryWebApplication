﻿// <auto-generated />
using System;
using LibraryWebApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryWebApplication.Migrations
{
    [DbContext(typeof(LibraryWebApplicationContext))]
    [Migration("20230605234813_DifferentModels")]
    partial class DifferentModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LibraryWebApplication.Models.Book", b =>
                {
                    b.Property<int>("bookID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("bookID"), 1L, 1);

                    b.Property<string>("author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("categoryID")
                        .HasColumnType("int");

                    b.Property<string>("coverImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isAvailable")
                        .HasColumnType("bit");

                    b.Property<int>("publishedYear")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("bookID");

                    b.HasIndex("categoryID");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("LibraryWebApplication.Models.Category", b =>
                {
                    b.Property<int>("categoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("categoryID"), 1L, 1);

                    b.Property<string>("categoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("categoryID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("LibraryWebApplication.Models.News", b =>
                {
                    b.Property<int>("newsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("newsID"), 1L, 1);

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("publishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("newsID");

                    b.ToTable("News");
                });

            modelBuilder.Entity("LibraryWebApplication.Models.ReaderCard", b =>
                {
                    b.Property<int>("recordID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("recordID"), 1L, 1);

                    b.Property<int>("bookID")
                        .HasColumnType("int");

                    b.Property<DateTime>("borrowDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isBorrowed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("returnDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("userID")
                        .HasColumnType("int");

                    b.HasKey("recordID");

                    b.HasIndex("bookID");

                    b.HasIndex("userID");

                    b.ToTable("ReaderCard");
                });

            modelBuilder.Entity("LibraryWebApplication.Models.Role", b =>
                {
                    b.Property<int>("roleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("roleID"), 1L, 1);

                    b.Property<string>("roleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("roleID");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("LibraryWebApplication.Models.User", b =>
                {
                    b.Property<int>("userID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userID"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isBlocked")
                        .HasColumnType("bit");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("roleID")
                        .HasColumnType("int");

                    b.HasKey("userID");

                    b.HasIndex("roleID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("LibraryWebApplication.Models.Wishlist", b =>
                {
                    b.Property<int>("wishlistID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("wishlistID"), 1L, 1);

                    b.Property<int>("bookID")
                        .HasColumnType("int");

                    b.Property<int>("userID")
                        .HasColumnType("int");

                    b.HasKey("wishlistID");

                    b.HasIndex("bookID");

                    b.HasIndex("userID");

                    b.ToTable("Wishlist");
                });

            modelBuilder.Entity("LibraryWebApplication.Models.Book", b =>
                {
                    b.HasOne("LibraryWebApplication.Models.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("categoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("LibraryWebApplication.Models.ReaderCard", b =>
                {
                    b.HasOne("LibraryWebApplication.Models.Book", "Book")
                        .WithMany("Cards")
                        .HasForeignKey("bookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryWebApplication.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LibraryWebApplication.Models.User", b =>
                {
                    b.HasOne("LibraryWebApplication.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("roleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("LibraryWebApplication.Models.Wishlist", b =>
                {
                    b.HasOne("LibraryWebApplication.Models.Book", "Book")
                        .WithMany("Wishlists")
                        .HasForeignKey("bookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryWebApplication.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LibraryWebApplication.Models.Book", b =>
                {
                    b.Navigation("Cards");

                    b.Navigation("Wishlists");
                });

            modelBuilder.Entity("LibraryWebApplication.Models.Category", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("LibraryWebApplication.Models.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}