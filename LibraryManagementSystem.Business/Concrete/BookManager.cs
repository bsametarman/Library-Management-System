using LibraryManagementSystem.Business.Abstract;
using LibraryManagementSystem.Business.ValidationRules.FluentValidation;
using LibraryManagementSystem.Core.Aspects.Postsharp;
using LibraryManagementSystem.DataAccess.Abstract;
using LibraryManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Business.Concrete
{
    public class BookManager : IBookService
    {
        private IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        [FluentValidationAspect(typeof(BookValidator))]
        public void Add(Book book)
        {
            _bookDal.Add(book);
        }

        public void Delete(Book book)
        {
            _bookDal.Delete(book);
        }

        public List<Book> GetAll()
        {
            return _bookDal.GetAll();
        }

        public Book GetById(int id)
        {
            return _bookDal.Get(p => p.BookId == id);
        }

        public void Update(Book book)
        {
            _bookDal.Update(book);
        }
    }
}
