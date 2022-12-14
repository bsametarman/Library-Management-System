using LibraryManagementSystem.Business.Abstract;
using LibraryManagementSystem.Business.ValidationRules.FluentValidation;
using LibraryManagementSystem.Core.Aspects.Postsharp;
using LibraryManagementSystem.Core.Utilities.Results;
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
        public IResult Add(Book book)
        {
            _bookDal.Add(book);
            return new SuccessResult("Başarıyla Eklendi !!!");
        }

        public IResult Delete(Book book)
        {
            _bookDal.Delete(book);
            return new SuccessResult("Başarıyla silindi !!!");
        }

        public IDataResult<List<Book>> GetAll()
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll(), "Başarıyla getirildi !!!");
        }

        public IDataResult<Book> GetById(int id)
        {
            return new SuccessDataResult<Book>(_bookDal.Get(p => p.BookId == id), "Başarıyla getirildi !!!");
        }

        public IResult Update(Book book)
        {
            _bookDal.Update(book);
            return new SuccessResult("Başarıyla güncellendi");
        }
    }
}
