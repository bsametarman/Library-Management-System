using LibraryManagementSystem.Business.Abstract;
using LibraryManagementSystem.Business.ValidationRules.FluentValidation;
using LibraryManagementSystem.Core.Aspects.Postsharp.ValidationAspects;
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
    public class GenreManager : IGenreService
    {
        private IGenreDal _genreDal;

        public GenreManager(IGenreDal genreDal)
        {
            _genreDal = genreDal;
        }

        [FluentValidationAspect(typeof(GenreValidator))]
        public IResult Add(Genre genre)
        {
            _genreDal.Add(genre);
            return new SuccessResult("Başarıyla eklendi !!!");
        }

        public IResult Delete(Genre genre)
        {
            _genreDal.Delete(genre);
            return new SuccessResult("Başarıyla silindi !!!");
        }

        public IDataResult<Genre> GetById(int id)
        {
            return new SuccessDataResult<Genre>(_genreDal.Get(g => g.GenreId == id), "Başarıyla listelendi !!!");
        }

        public IDataResult<List<Genre>> GetAll()
        {
            return new SuccessDataResult<List<Genre>>(_genreDal.GetAll(), "Başarıyla listelendi !!!");
        }

        public IResult Update(Genre genre)
        {
            _genreDal.Update(genre);
            return new SuccessResult("Başarıyla güncellendi !!!");
        }
    }
}
