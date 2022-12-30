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
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int id);
        IResult GetByEmailAndPassword(string email, string password);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
    }
}
