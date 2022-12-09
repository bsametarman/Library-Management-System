using LibraryManagementSystem.Business.Abstract;
using LibraryManagementSystem.DataAccess.Abstract;
using LibraryManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Business.Concrete
{
    public class PublisherManager : IPublisherService
    {
        private IPublisherDal _publisherDal;

        public PublisherManager(IPublisherDal publisherDal)
        {
            _publisherDal = publisherDal;
        }

        public void Add(Publisher publisher)
        {
            _publisherDal.Add(publisher);
        }

        public void Delete(Publisher publisher)
        {
            _publisherDal.Delete(publisher);
        }

        public Publisher Get(int id)
        {
            return _publisherDal.Get(p => p.PublisherId == id);
        }

        public List<Publisher> GetAll()
        {
            return _publisherDal.GetAll();
        }

        public void Update(Publisher publisher)
        {
            _publisherDal.Update(publisher);
        }
    }
}
