﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data.Entities;
using Library.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Domain.Repositories
{
    public class BookRentRepository
    {
        public BookRentRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
            
        }
        private readonly LibraryContext _libraryContext;
        public List<BookRent> GetAllBookRents()
        {
            return _libraryContext.BookRents.ToList();
        }
        public void AddBookRent(BookRent bookRentToAdd)
        {
            _libraryContext.BookRents.Add(bookRentToAdd);
            _libraryContext.SaveChanges();
        }
        public BookRent GetBookRent(int bookId,int studentId)
        {
            return _libraryContext.BookRents.Include(x => x.Book).Include(x => x.Student)
                .FirstOrDefault(x => x.BookId == bookId && x.StudentId == studentId);
        }

    }
}
