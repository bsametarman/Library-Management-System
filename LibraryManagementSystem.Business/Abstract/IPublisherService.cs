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
        List<Publisher> GetAll();
        Publisher Get(int id);
        void Add(Publisher publisher);
        void Update(Publisher publisher);
        void Delete(Publisher publisher);

    }
}
