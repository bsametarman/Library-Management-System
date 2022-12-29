using LibraryManagementSystem.Core.DataAccess;
using LibraryManagementSystem.Core.Utilities.Results;
using LibraryManagementSystem.Entities.ComplexTypes;
using LibraryManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DataAccess.Abstract
{
    public interface IAuthorDal : IEntityRepository<Author>
    {
        List<AuthorDetail> GetAllAuthorsWithDetails();
    }
}
