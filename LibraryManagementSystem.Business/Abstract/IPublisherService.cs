using LibraryManagementSystem.Core.Utilities.Results;
using LibraryManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Business.Abstract
{
    public interface IPublisherService
    {
        IDataResult<List<Publisher>> GetAll();
        IDataResult<Publisher> Get(int id);
        IResult Add(Publisher publisher);
        IResult Update(Publisher publisher);
        IResult Delete(Publisher publisher);

    }
}
