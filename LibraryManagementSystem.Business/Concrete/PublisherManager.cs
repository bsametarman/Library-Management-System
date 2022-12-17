using LibraryManagementSystem.Business.Abstract;
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
    public class PublisherManager : IPublisherService
    {
        private IPublisherDal _publisherDal;

        public PublisherManager(IPublisherDal publisherDal)
        {
            _publisherDal = publisherDal;
        }

        public IResult Add(Publisher publisher)
        {
            _publisherDal.Add(publisher);
            return new SuccessResult("Başarıyla eklendi !!!");
        }

        public IResult Delete(Publisher publisher)
        {
            _publisherDal.Delete(publisher);
            return new SuccessResult("Başarıyla silindi !!!");
        }

        public IDataResult<Publisher> GetById(int id)
        {
            return new SuccessDataResult<Publisher>(_publisherDal.Get(p => p.PublisherId == id), "Başarıyla listelendi !!!");
        }

        public IDataResult<List<Publisher>> GetAll()
        {
            return new SuccessDataResult<List<Publisher>>(_publisherDal.GetAll(), "Başarıyla listelendi !!!");
        }

        public IResult Update(Publisher publisher)
        {
            _publisherDal.Update(publisher);
            return new SuccessResult("Başarıyla güncellendi !!!");
        }
    }
}
