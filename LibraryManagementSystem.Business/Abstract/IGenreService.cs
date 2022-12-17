using LibraryManagementSystem.Core.Utilities.Results;
using LibraryManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Business.Abstract
{
    public interface IGenreService
    {
        IDataResult<List<Genre>> GetAll();
        IDataResult<Genre> GetById(int id);
        IResult Add(Genre genre);
        IResult Update(Genre genre);
        IResult Delete(Genre genre);
    }
}
