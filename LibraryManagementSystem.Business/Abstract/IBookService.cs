﻿using LibraryManagementSystem.Core.Utilities.Results;
using LibraryManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Entities.ComplexTypes;

namespace LibraryManagementSystem.Business.Abstract
{
    public interface IBookService
    {
        IDataResult<List<Book>> GetAll();
        IDataResult<Book> GetById(int id);
        IDataResult<List<BookDetail>> GetAllBooksWithDetails();
        IResult Add(Book book);
        IResult Update(Book book);
        IResult Delete(Book book);
    }
}
