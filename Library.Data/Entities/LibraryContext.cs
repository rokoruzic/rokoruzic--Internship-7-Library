﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Library.Data.Entities
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookRent> BookRents { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<AuthorBook> AuthorsBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorBook>()
                .HasKey(bc => new { bc.BookId, bc.AuthorId });
            modelBuilder.Entity<AuthorBook>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.AuthorsBooks)
                .HasForeignKey(bc => bc.BookId);
            modelBuilder.Entity<AuthorBook>()
                .HasOne(bc => bc.Author)
                .WithMany(c => c.AuthorsBooks)
                .HasForeignKey(bc => bc.AuthorId);

            modelBuilder.Entity<BookRent>()
                .HasKey(bc => new { bc.BookId, bc.StudentId });
            modelBuilder.Entity<BookRent>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookRents)
                .HasForeignKey(bc => bc.BookId);
            modelBuilder.Entity<BookRent>()
                .HasOne(bc => bc.Student)
                .WithMany(c => c.BookRents)
                .HasForeignKey(bc => bc.StudentId);


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["LibraryDatabase"].ConnectionString);
        }
    }
}
