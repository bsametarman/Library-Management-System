using LibraryManagementSystem.Core.DataAccess.EntityFramework;
using LibraryManagementSystem.Core.Utilities.Results;
using LibraryManagementSystem.DataAccess.Abstract;
using LibraryManagementSystem.Entities.ComplexTypes;
using LibraryManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DataAccess.Concrete
{
	public class EfAuthorDal : EfEntityRepositoryBase<Author, LibraryContext>, IAuthorDal
	{
		public List<AuthorDetail> GetAllAuthorsWithDetails()
		{
			using (LibraryContext context = new LibraryContext())
			{
				var authorsWithDetails = (from a in context.Authors
					join b in context.Books on a.BookId equals b.BookId
					select new AuthorDetail
					{
						AuthorId = a.AuthorId,
						AuthorName = a.AuthorName,
						BookId = b.BookId,
						BookName = b.BookName,
						BirthYear = a.BirthYear,
						DeathYear = a.DeathYear,
						Gender = a.Gender,
						Email = a.Email,
						InternetSite = a.InternetSite
					}).ToList();
				return authorsWithDetails;
			}
		}
	}
}
