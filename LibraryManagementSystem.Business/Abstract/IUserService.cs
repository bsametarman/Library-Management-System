using LibraryManagementSystem.Core.Utilities.Results;
using LibraryManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<AppUser>> GetAll();
        IDataResult<AppUser> GetById(string id);
        IResult GetByEmailAndPassword(string email, string password);
        IResult Add(AppUser user);
        IResult Update(AppUser user);
        IResult Delete(AppUser user);
    }
}
