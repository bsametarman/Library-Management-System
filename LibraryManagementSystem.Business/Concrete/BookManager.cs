using LibraryManagementSystem.Business.Abstract;
using LibraryManagementSystem.Business.ValidationRules.FluentValidation;
using LibraryManagementSystem.Core.Aspects.Postsharp.AuthorizationAspects;
using LibraryManagementSystem.Core.Aspects.Postsharp.CacheAspect;
using LibraryManagementSystem.Core.Aspects.Postsharp.LogAspects;
using LibraryManagementSystem.Core.Aspects.Postsharp.TransactionAspects;
using LibraryManagementSystem.Core.Aspects.Postsharp.ValidationAspects;
using LibraryManagementSystem.Core.CrossCuttingConcerns.Caching.Microsoft;
using LibraryManagementSystem.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using LibraryManagementSystem.Core.Utilities.Results;
using LibraryManagementSystem.DataAccess.Abstract;
using LibraryManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Entities.ComplexTypes;

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
        [TransactionScopeAspect]
        [LogAspect(typeof(DatabaseLogger))]
        public IResult Add(Book book)
        {
            _bookDal.Add(book);
            return new SuccessResult("Başarıyla Eklendi !!!");
        }

        [LogAspect(typeof(DatabaseLogger))]
        public IResult Delete(Book book)
        {
            _bookDal.Delete(book);
            return new SuccessResult("Başarıyla silindi !!!");
        }

        [CacheAspect(typeof(MemoryCacheManager), 60)]
        [LogAspect(typeof(DatabaseLogger))]
        //[SecuredOperation(Roles = "Admin")]
        public IDataResult<List<Book>> GetAll()
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll(), "Başarıyla getirildi !!!");
        }

        [CacheAspect(typeof(MemoryCacheManager), 60)]
        [LogAspect(typeof(DatabaseLogger))]
		public IDataResult<List<BookDetail>> GetAllBooksWithDetails()
        {
	        return new SuccessDataResult<List<BookDetail>>(_bookDal.GetAllBooksWithDetails(), "Başarıyla listelendi!!!");
        }

        [LogAspect(typeof(DatabaseLogger))]
        public IDataResult<Book> GetById(int id)
        {
            return new SuccessDataResult<Book>(_bookDal.Get(p => p.BookId == id), "Başarıyla getirildi !!!");
        }

        [LogAspect(typeof(DatabaseLogger))]
        public IResult Update(Book book)
        {
            _bookDal.Update(book);
            return new SuccessResult("Başarıyla güncellendi");
        }
    }
}
