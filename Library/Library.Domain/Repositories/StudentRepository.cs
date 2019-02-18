﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Library.Data.Entities;
using Library.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Domain.Repositories
{
   public class StudentRepository
    {
        public StudentRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        private readonly LibraryContext _libraryContext;

        public Student GetStudent(int id)
        {
            return _libraryContext.Students.Include(x=>x.BookRents).FirstOrDefault(x=>x.StudentId==id );
        }
        public List<Student> GetAllStudents()
        {
            return _libraryContext.Students.Include(x => x.BookRents).ToList();
        }

        public void AddStudent(Student studentToAdd)
        {
            _libraryContext.Students.Add(studentToAdd);
            _libraryContext.SaveChanges();
        }

        public bool RemoveStudent(int id)
        {
            var studentToRemove = _libraryContext.Students.FirstOrDefault(x => x.StudentId == id);
            if (studentToRemove == null) return false;
            _libraryContext.Students.Remove(studentToRemove);
            _libraryContext.SaveChanges();
            return true;
        }

        public bool EditStudent(Student studentToEdit)
        {
            var editedStudent = _libraryContext.Students.FirstOrDefault(x => x.StudentId == studentToEdit.StudentId);
            if (editedStudent == null) return false;
            editedStudent.FirstName = studentToEdit.FirstName;
            editedStudent.LastName = studentToEdit.LastName;
            editedStudent.Class = studentToEdit.Class;
            editedStudent.DateOfBirth = studentToEdit.DateOfBirth;
            editedStudent.StudentId = studentToEdit.StudentId;
            //editedStudent.BookRents = studentToEdit.BookRents;
            //_libraryContext.Attach(studentToEdit.BookRents);

            _libraryContext.SaveChanges();
            return true;

        }

       

        public int GetNewId()
        {
            return _libraryContext.Students.Count() + 1;
        }

        //public bool IsRentActive(Student studentToCheckRent,List<BookRent> bookRents)
        //{
        //    return studentToCheckRent.IsRentActive && bookRents.FirstOrDefault(x=>x.StudentId==studentToCheckRent.StudentId).DateOfReturn==null;
        //}
       
    }
}
