using LibraryManagementSystem.Core.DataAccess.EntityFramework;
using LibraryManagementSystem.DataAccess.Abstract;
using LibraryManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Core.Utilities.Results;
using LibraryManagementSystem.Entities.ComplexTypes;

namespace LibraryManagementSystem.DataAccess.Concrete
{
    public class EfBookDal : EfEntityRepositoryBase<Book, LibraryContext>, IBookDal
    {
	    public List<BookDetail> GetAllBooksWithDetails()
	    {
		    using (LibraryContext context = new LibraryContext())
		    {
			    var booksWithAuthors = (from b in context.Books
				    join a in context.Authors on b.AuthorId equals a.AuthorId
				    select new BookDetail
				    {
					    BookId = b.BookId,
					    BookName = b.BookName,
					    AuthorName = a.AuthorName,
					    AuthorEmail = a.Email,
						TranslatorId = b.TranslatorId,
						GenreId= b.GenreId,
						ISBN = b.ISBN,
					    Publisher = b.Publisher,
					    PublishedYear = b.PublishedYear,
					    AvailableState = b.AvailableState,
					    ShelfNumber = b.ShelfNumber,
					    ReturnDate = b.ReturnDate,
					    ShortSummary = b.ShortSummary
				    }).ToList();

			    var booksWithTranslators = (from b in booksWithAuthors
				    join t in context.Translators on b.TranslatorId equals t.TranslatorId
				    select new BookDetail
				    {
						BookId = b.BookId,
						BookName = b.BookName,
						AuthorName = b.AuthorName,
						AuthorEmail = b.AuthorEmail,
						TranslatorId = b.TranslatorId,
						TranslatorName = t.TranslatorName,
						TranslatorEmail = t.Email,
						GenreId= b.GenreId,
						ISBN = b.ISBN,
						Publisher = b.Publisher,
						PublishedYear = b.PublishedYear,
						AvailableState = b.AvailableState,
						ShelfNumber = b.ShelfNumber,
						ReturnDate = b.ReturnDate,
						ShortSummary = b.ShortSummary					    
				    }).ToList();

				var booksWithAllDetails = (from b in booksWithTranslators
					join g in context.Genres on b.GenreId equals g.GenreId
					select new BookDetail
					{
						BookId = b.BookId,
						BookName = b.BookName,
						AuthorName = b.AuthorName,
						AuthorEmail = b.AuthorEmail,
						TranslatorId = b.TranslatorId,
						TranslatorName = b.TranslatorName,
						TranslatorEmail = b.TranslatorEmail,
						GenreId= b.GenreId,
						GenreName = g.GenreName,
						ISBN = b.ISBN,
						Publisher = b.Publisher,
						PublishedYear = b.PublishedYear,
						AvailableState = b.AvailableState,
						ShelfNumber = b.ShelfNumber,
						ReturnDate = b.ReturnDate,
						ShortSummary = b.ShortSummary
					}).ToList();

				return booksWithAllDetails.ToList();
		    }
	    }
    }
}
