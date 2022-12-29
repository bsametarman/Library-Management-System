using LibraryManagementSystem.Core.Utilities.Results;
using LibraryManagementSystem.Entities.ComplexTypes;
using LibraryManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Business.Abstract
{
    public interface IAuthorService
    {
        IDataResult<List<Author>> GetAll();
        IDataResult<Author> GetById(int id);
        IDataResult<List<AuthorDetail>> GetAllAuthorsWithDetails();
        IResult Add(Author author);
        IResult Update(Author author);
        IResult Delete(Author author);
    }
}
