﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RiverBooks.Books;

#nullable disable

namespace RiverBooks.Books.Data.Migrations
{
    [DbContext(typeof(BookDbContext))]
    partial class BookDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Books")
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RiverBooks.Books.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 6)
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Books", "Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("eac9a9e8-5446-4553-8ed4-fe66c88299ab"),
                            Author = "J.R.R. Tolkien",
                            Price = 9.99m,
                            Title = "The Hobbit"
                        },
                        new
                        {
                            Id = new Guid("81a8cdd9-c1cb-48d7-9cff-c76ea9502518"),
                            Author = "J.R.R. Tolkien",
                            Price = 10.99m,
                            Title = "The Fellowship of the Ring"
                        },
                        new
                        {
                            Id = new Guid("376d55c1-713d-4c6e-a905-d6e8808c1979"),
                            Author = "J.R.R. Tolkien",
                            Price = 11.99m,
                            Title = "The Two Towers"
                        },
                        new
                        {
                            Id = new Guid("1cd306a6-8cfe-4719-b8f6-bfbc44202833"),
                            Author = "J.R.R. Tolkien",
                            Price = 12.99m,
                            Title = "The Return of the King"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}