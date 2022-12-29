using LibraryManagementSystem.Business.Abstract;
using LibraryManagementSystem.Core.Utilities.Results;
using LibraryManagementSystem.DataAccess.Abstract;
using LibraryManagementSystem.Entities.ComplexTypes;
using LibraryManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Business.Concrete
{
    public class AuthorManager : IAuthorService
    {
        private IAuthorDal _authorDal;

        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

        public IResult Add(Author author)
        {
            _authorDal.Add(author);
            return new SuccessResult("Başarıyla eklendi !!!");
        }

        public IResult Delete(Author author)
        {
            _authorDal.Delete(author);
            return new SuccessResult("Başarıyla silindi !!!");
        }

        public IDataResult<List<Author>> GetAll()
        {
            return new SuccessDataResult<List<Author>>(_authorDal.GetAll(), "Başarıyla listelendi !!!");
        }

        public IDataResult<List<AuthorDetail>> GetAllAuthorsWithDetails()
        {
            return new SuccessDataResult<List<AuthorDetail>>(_authorDal.GetAllAuthorsWithDetails(), "Başarıyla listelendi!!!");
        }

        public IDataResult<Author> GetById(int id)
        {
            return new SuccessDataResult<Author>(_authorDal.Get(a => a.AuthorId == id), "Başarıyla getirildi !!!");
        }

        public IResult Update(Author author)
        {
            _authorDal.Update(author);
            return new SuccessResult("Başarıyla güncellendi !!!");
        }
    }
}
