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
    public class GenreManager : IGenreService
    {
        private IGenreDal _genreDal;

        public GenreManager(IGenreDal genreDal)
        {
            _genreDal = genreDal;
        }

        [FluentValidationAspect(typeof(GenreValidator))]
        public void Add(Genre genre)
        {
            _genreDal.Add(genre);
        }

        public void Delete(Genre genre)
        {
            _genreDal.Delete(genre);
        }

        public Genre Get(int id)
        {
            return _genreDal.Get(g => g.GenreId == id);
        }

        public List<Genre> GetAll()
        {
            return _genreDal.GetAll();
        }

        public void Update(Genre genre)
        {
            _genreDal.Update(genre);
        }
    }
}
