﻿// <auto-generated />
using System;
using Library.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Library.Data.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Library.Data.Entities.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Library.Data.Entities.Models.AuthorBook", b =>
                {
                    b.Property<int>("BookId");

                    b.Property<int>("AuthorId");

                    b.HasKey("BookId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("AuthorsBooks");
                });

            modelBuilder.Entity("Library.Data.Entities.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Genre");

                    b.Property<bool>("IsRentActive");

                    b.Property<string>("Name");

                    b.Property<int>("Pages");

                    b.Property<int>("PublisherId");

                    b.HasKey("BookId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Library.Data.Entities.Models.BookRent", b =>
                {
                    b.Property<int>("BookRentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId");

                    b.Property<DateTime>("DateOfRent");

                    b.Property<DateTime?>("DateOfReturn");

                    b.Property<int>("StudentId");

                    b.HasKey("BookRentId");

                    b.HasIndex("BookId");

                    b.HasIndex("StudentId");

                    b.ToTable("BookRents");
                });

            modelBuilder.Entity("Library.Data.Entities.Models.Publisher", b =>
                {
                    b.Property<int>("PublisherId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("PublisherId");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("Library.Data.Entities.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Class");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FirstName");

                    b.Property<int>("Gender");

                    b.Property<string>("LastName");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Library.Data.Entities.Models.AuthorBook", b =>
                {
                    b.HasOne("Library.Data.Entities.Models.Author", "Author")
                        .WithMany("AuthorsBooks")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Library.Data.Entities.Models.Book", "Book")
                        .WithMany("AuthorsBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Library.Data.Entities.Models.Book", b =>
                {
                    b.HasOne("Library.Data.Entities.Models.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Library.Data.Entities.Models.BookRent", b =>
                {
                    b.HasOne("Library.Data.Entities.Models.Book", "Book")
                        .WithMany("BookRents")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Library.Data.Entities.Models.Student", "Student")
                        .WithMany("BookRents")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
